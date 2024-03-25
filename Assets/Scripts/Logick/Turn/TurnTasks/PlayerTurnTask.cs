using System.Collections.Generic;
using Logick.Events;
using UnityEngine;

namespace Logick.Turn.Tasks
{
    public sealed class PlayerTurnTask : TurnTask
    {
        private readonly List<EntityButtonListener> _buttons;
        private readonly EventBus _eventBus;
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;

        public PlayerTurnTask(List<EntityButtonListener> buttons, EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity)
        {
            _buttons = buttons;
            _eventBus = eventBus;
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
        }

        protected override void OnRun()
        {
            foreach (var listener in _buttons)
            {
                listener.OnTargetClicked += OnTargetClicked;    
            }
        }

        protected override void OnFinish()
        {
            foreach (var listener in _buttons)
            {
                listener.OnTargetClicked -= OnTargetClicked;    
            }
        }

        private void OnTargetClicked(EntityConfig entity)
        {
            if (entity.IsDead || entity.Team == _currentEntity.Value.Team)
                return;
            if (_currentEntity.Value.SkipAttackTargeting)
            {
                _currentEntity.Value.SkipAttackTargeting = false;
                _eventBus.RaiseEvent(new AttackEvent(_currentEntity.Value, _attackedEntity.Value));
            }
            else
            {
                _eventBus.RaiseEvent(new AttackEvent(_currentEntity.Value, entity));
                _attackedEntity.Value = entity;   
            }
            Finish();
        }
    }
}
