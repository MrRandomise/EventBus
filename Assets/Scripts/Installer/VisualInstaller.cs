using Logick.Handlers.Visual;
using Logick.Turn.Visual;
using Logick.Turn.Tasks;
using Zenject;

namespace DiInstaller
{
    public class VisualInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<VisualTurnAdapter>().AsSingle();

            Container.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExtraAttackVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DrawStatsVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivateEntityVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeactivateEntityVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartTurnVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SwitchHeroVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SkillsUsedVisualHandler>().AsSingle();

            Container.Bind<StartVisualTurnTask>().AsSingle();
        }
    }
}