using System;
using Zenject;
using Logick.Turn.Tasks;

namespace Logick.Turn
{
    public sealed class TurnInstaller: IInitializable, IDisposable
    {
        private readonly Turn _turn;

        private readonly DiContainer _container;

        public TurnInstaller(DiContainer container, Turn turn)
        {
            _container = container;
            _turn = turn;
        }

        public void Initialize()
        {
            _turn.AddTask(_container.Resolve<StartGameTask>());
            _turn.AddTask(_container.Resolve<StartTurnTask>());
            _turn.AddTask(_container.Resolve<BeforeAttackSkillsTask>());
            _turn.AddTask(_container.Resolve<PlayerTurnTask>());
            _turn.AddTask(_container.Resolve<AfterAttackSkillsTask>());
            _turn.AddTask(_container.Resolve<StrikeTask>());
            _turn.AddTask(_container.Resolve<EndTurnSkillsTask>());
            _turn.AddTask(_container.Resolve<AfterStrikeSkillsTask>());
            _turn.AddTask(_container.Resolve<GlobalSkillsTask>());
            _turn.AddTask(_container.Resolve<SwitchHeroTask>());
            _turn.AddTask(_container.Resolve<StartVisualTurnTask>());
            _turn.AddTask(_container.Resolve<EndTurnTask>());
        }

        public void Dispose()
        {
            _turn.Clear();
        }
    }
}
