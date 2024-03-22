using Logick.Events;
using UnityEngine;

namespace Logick.Turn.Tasks
{
    public sealed class StartTurnTask : TurnTask
    {
        private int _turnCount;
        private readonly EventBus _eventBus;

        public StartTurnTask(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            _turnCount++;
            _eventBus.RaiseEvent(new StartTurnEvent(_turnCount));
            Debug.Log($"Начался {_turnCount} ход!");
            Finish();
        }
    }
}
