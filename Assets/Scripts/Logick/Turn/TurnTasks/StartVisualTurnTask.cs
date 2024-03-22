namespace Logick.Turn.Tasks
{
    public sealed class StartVisualTurnTask : TurnTask
    {
        private readonly Turn _visualTurn;

        public StartVisualTurnTask(Turn visualTurn)
        {
            _visualTurn = visualTurn;
        }

        protected override void OnRun()
        {
            _visualTurn.OnFinished += OnVisualTurnFinished;
            _visualTurn.Run();
        }

        protected override void OnFinish()
        {
            _visualTurn.OnFinished -= OnVisualTurnFinished;
        }

        private void OnVisualTurnFinished()
        {
            _visualTurn.Clear();
            Finish();
        }
    }
}
