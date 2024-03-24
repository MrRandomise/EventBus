using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Logick.Turn
{
    public sealed class TurnRunner : MonoBehaviour
    {
        [SerializeField] private bool _runOnStart = true;
        [SerializeField] private bool _runOnFinish = true;
        
        private TurnAdapter _turn;

        [Inject]
        private void Construct(TurnAdapter turn)
        {
            _turn = turn;
        }

        public void StopTurn()
        {
            _runOnFinish = false;
        }

        private void Start()
        {
            if(_runOnStart) Run();
        }

        private void OnEnable()
        {
            _turn.OnFinished += OnTurnFinished;
        }

        private void OnDisable()
        {
            _turn.OnFinished -= OnTurnFinished;
        }

        [Button]
        private void Run()
        {
            _turn.Run();
        }

        private void OnTurnFinished()
        {
            if(_runOnFinish) Run();
        }
    }
}
