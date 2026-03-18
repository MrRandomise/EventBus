# EventBus — Учебный проект курса OTUS

> Демонстрация паттерна **EventBus (Publisher-Subscriber)** на Unity с пошаговой боевой системой.

---

## О проекте

Этот проект разработан в рамках обучающего курса **OTUS «Unity Developer»**. Цель — глубокое изучение паттерна EventBus (шина событий) и его практическое применение в игровой архитектуре.

Реализована пошаговая боевая игра с двумя командами героев, где вся коммуникация между подсистемами (боевая логика, визуализация, навыки) осуществляется через единую шину событий.

---

## Чему я научился

- Реализация паттерна **EventBus** «с нуля» на C# без сторонних библиотек
- Построение **слабосвязанной (loosely coupled)** архитектуры
- Разделение **игровой логики** и **визуального слоя** через события
- Построение очереди событий для обработки вложенных вызовов
- Работа с **Dependency Injection** через Zenject
- Пошаговая система на основе **Chain of Responsibility** (задачи хода)
- Система навыков на паттерне **Strategy**

---

## Паттерн EventBus

EventBus — это посредник, который позволяет компонентам обмениваться событиями без прямых ссылок друг на друга.

```
Отправитель ──▶ EventBus ──▶ Подписчики
```

### Ключевые возможности реализации

| Возможность | Описание |
|-------------|----------|
| `Subscribe<T>` | Подписка на событие конкретного типа |
| `Unsubscribe<T>` | Отписка от события |
| `RaiseEvent<T>` | Публикация события с очередью для вложенных вызовов |
| Безопасная отписка | Корректная обработка отписки во время итерации по подписчикам |

### Пример использования

```csharp
// Подписка
eventBus.Subscribe<AttackEvent>(OnAttack);

// Публикация
eventBus.RaiseEvent(new AttackEvent(attacker, target));

// Отписка
eventBus.Unsubscribe<AttackEvent>(OnAttack);
```

---

## Архитектура проекта

```
Assets/Scripts/
├── Logick/
│   ├── EventBus.cs                  # Ядро: шина событий
│   ├── EventHandlerCollection.cs    # Коллекция обработчиков (partial class)
│   ├── IEventHandlerCollection.cs   # Интерфейс коллекции
│   ├── EntityConfig.cs              # Конфигурация и состояние героя
│   ├── EntityStorage.cs             # Хранилище команд и героев
│   ├── CurrentEntity.cs             # Текущий ходящий герой
│   ├── AttackedEntity.cs            # Текущая цель атаки
│   │
│   ├── Events/                      # Все события игры
│   │   ├── IEvent.cs                # Маркерный интерфейс событий
│   │   ├── AttackEvent.cs           # Атака
│   │   ├── DealDamageEvent.cs       # Нанесение урона
│   │   ├── HealEvent.cs             # Лечение
│   │   ├── DestroyEvent.cs          # Уничтожение героя
│   │   ├── SkipTurnEvent.cs         # Пропуск хода
│   │   ├── ExtraAttackEvent.cs      # Дополнительная атака
│   │   ├── DisableStrikeBackEvent.cs# Запрет контратаки
│   │   └── ...
│   │
│   ├── Turn/
│   │   ├── Turn.cs                  # Контейнер задач хода
│   │   ├── TurnRunner.cs            # Запуск и зацикливание ходов
│   │   ├── TurnTask.cs              # Базовый класс задачи
│   │   ├── TurnInstaller.cs         # Сборка хода из задач (Zenject)
│   │   │
│   │   ├── TurnTasks/               # Задачи логики хода
│   │   │   ├── StartGameTask.cs     # Инициализация игры
│   │   │   ├── StartTurnTask.cs     # Начало хода
│   │   │   ├── PlayerTurnTask.cs    # Выбор цели игроком
│   │   │   ├── StrikeTask.cs        # Контратака
│   │   │   ├── BeforeAttackSkillsTask.cs
│   │   │   ├── AfterAttackSkillsTask.cs
│   │   │   ├── EndTurnTask.cs
│   │   │   └── ...
│   │   │
│   │   ├── HandlerTurn/             # Обработчики событий (логика)
│   │   │   ├── AttackHandler.cs     # Обработка атаки → урон
│   │   │   ├── DealDamageHandler.cs # Обработка урона → уничтожение
│   │   │   ├── HealHandler.cs       # Восстановление здоровья
│   │   │   └── ...
│   │   │
│   │   └── HandlerVisual/           # Обработчики событий (визуал)
│   │       ├── AttackVisualHandler.cs
│   │       ├── DealDamageVisualHandler.cs
│   │       └── ...
│   │
│   └── HeroesSkills/                # Навыки героев (паттерн Strategy)
│       ├── BaseSkills.cs
│       ├── MassAttack.cs            # Атака по всем врагам
│       ├── FrozeEnemy.cs            # Заморозка врага (пропуск хода)
│       ├── GodShield.cs             # Щит: лечение при первом ударе
│       ├── HealthDrain.cs           # Вампиризм (шанс лечения)
│       ├── RandomHeal.cs            # Лечение случайного союзника
│       ├── NoStrikeBack.cs          # Запрет контратаки
│       └── ...
│
├── HeroConfig/
│   └── HeroConfig.cs                # ScriptableObject с параметрами героя
│
├── UI/
│   ├── HeroView.cs                  # Визуальное представление героя
│   ├── HeroListView.cs              # Список героев команды
│   ├── UIService.cs                 # Сервис управления UI
│   └── VfxView.cs                   # Визуальные эффекты
│
└── Installer/
    ├── SceneInstaller.cs            # Zenject: регистрация зависимостей
    ├── TurnConfigInstaller.cs
    └── VisualInstaller.cs
```

---

## Поток событий за один ход

```
StartTurnTask
    └─▶ RaiseEvent(StartTurnEvent)
            └─▶ StartTurnVisualHandler (анимация начала хода)

PlayerTurnTask  ← ожидает клик игрока
    └─▶ RaiseEvent(AttackEvent)
            └─▶ AttackHandler → RaiseEvent(DealDamageEvent)
                    └─▶ DealDamageHandler → (если HP ≤ 0) RaiseEvent(DestroyEvent)
                    └─▶ DealDamageVisualHandler (анимация урона)

StrikeTask  ← контратака цели
    └─▶ RaiseEvent(AttackEvent) ...

EndTurnTask
    └─▶ Смена активного героя
```

---

## Технологии и инструменты

| Инструмент | Версия | Применение |
|------------|--------|------------|
| **Unity** | 2022+ | Игровой движок |
| **C#** | 9.0 | Язык разработки |
| **Zenject** | — | Dependency Injection |
| **Odin Inspector** | — | Расширенный инспектор в редакторе |
| **UniTask** | — | Асинхронные операции |
| **DOTween** | — | Анимации и твины |

---

## Паттерны проектирования

- **EventBus / Publisher-Subscriber** — основа архитектуры
- **Chain of Responsibility** — система задач хода (`Turn` + `TurnTask`)
- **Strategy** — навыки героев (`BaseSkills`)
- **Dependency Injection** — Zenject для управления зависимостями

---

## Демонстрация навыков

Этот проект демонстрирует следующие профессиональные компетенции:

✅ Проектирование слабосвязанной архитектуры на C# и Unity  
✅ Реализация классических паттернов GoF в игровом контексте  
✅ Разделение бизнес-логики и представления (логика ≠ визуал)  
✅ Применение Dependency Injection (Zenject)  
✅ Написание расширяемого и поддерживаемого кода  
✅ Работа с ScriptableObject для конфигурации данных

---

## Запуск проекта

1. Клонировать репозиторий
2. Открыть в **Unity 2022** или новее
3. Открыть сцену `Assets/Scenes/SampleScene.unity`
4. Нажать **Play**

---

*Проект выполнен в рамках курса [OTUS «Unity Developer»](https://otus.ru/lessons/unity-gamedev/)*
