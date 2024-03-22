using UnityEngine;

namespace Logick.Turn.Tasks
{
    public sealed class EndTurnTask : TurnTask
    {
        private readonly EntityStorage _entityStorage;
        private readonly TurnRunner _turnRunner;

        public EndTurnTask(EntityStorage entityStorage, TurnRunner turnRunner)
        {
            _entityStorage = entityStorage;
            _turnRunner = turnRunner;
        }

        protected override void OnRun()
        {
            Debug.Log("Конец хода");
            if (!_entityStorage.HasAliveHeroes(true) || !_entityStorage.HasAliveHeroes(false))
            {
                _turnRunner.StopTurn();
                Debug.Log("Игра окончена!!!");
            }
            Finish();
        }
    }
}
