using System.Collections.Generic;
using Logick.Events;
using UnityEngine;

namespace Logick.Turn.Tasks
{
    public sealed class StartGameTask : TurnTask
    {
        private bool _gameStarted;
        private readonly EventBus _eventBus;
        private readonly EntityStorage _entityStorage;
        private readonly CurrentEntity _currentEntity;
        private readonly StartVisualTurnTask _startVisualTurnTask;

        public StartGameTask(EventBus eventBus, EntityStorage entityStorage, CurrentEntity currentEntity, StartVisualTurnTask startVisualTask)
        {
            _eventBus = eventBus;
            _entityStorage = entityStorage;
            _currentEntity = currentEntity;
            _startVisualTurnTask = startVisualTask;
        }

        protected override void OnRun()
        {
            if (_gameStarted)
            {
                Finish();
                return;
            }
            var entities = new List<EntityConfig>();
            entities.AddRange(_entityStorage.GetTeam(true));
            entities.AddRange(_entityStorage.GetTeam(false));
            foreach (var entity in entities)
            {
                _eventBus.RaiseEvent(new DrawStatEvent(entity));
            }

            _currentEntity.Value = _entityStorage.GetStartEntity();
            _gameStarted = true;
            _startVisualTurnTask.Run(Finish);
        }
    }
}
