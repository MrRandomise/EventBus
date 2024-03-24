using Logick.Handlers.Turn;
using Logick.Turn.Tasks;
using Logick.Turn;
using Zenject;
using UnityEngine;

namespace DiInstaller
{
    public class TurnConfigInstaller : MonoInstaller
    {
        [SerializeField] private TurnRunner _turnRunner;

        public override void InstallBindings()
        {
            Container.Bind<TurnAdapter>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurnInstaller>().AsSingle();
            Container.Bind<TurnRunner>().FromInstance(_turnRunner);

            Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExtraAttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DisableStrikeBackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SkipTurnHandler>().AsSingle();

            Container.Bind<StartTurnTask>().AsSingle();
            Container.Bind<PlayerTurnTask>().AsSingle();
            Container.Bind<StartGameTask>().AsSingle();
            Container.Bind<StrikeTask>().AsSingle();
            Container.Bind<EndTurnSkillsTask>().AsSingle();
            Container.Bind<AfterStrikeSkillsTask>().AsSingle();
            Container.Bind<BeforeAttackSkillsTask>().AsSingle();
            Container.Bind<AfterAttackSkillsTask>().AsSingle();
            Container.Bind<GlobalSkillsTask>().AsSingle();
            Container.Bind<EndTurnTask>().AsSingle();
            Container.Bind<SwitchHeroTask>().AsSingle();
        }
    }
}