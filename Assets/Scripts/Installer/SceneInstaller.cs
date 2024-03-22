using Logick;
using UI;
using Zenject;

namespace DiInstaller
{
    public sealed class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
            Container.Bind<CurrentEntity>().AsSingle();
            Container.Bind<AttackedEntity>().AsSingle();
            Container.Bind<EntityButtonListener>().FromComponentsInHierarchy().AsTransient();
            Container.Bind<HeroListView>().FromComponentsInHierarchy().AsTransient();
            Container.Bind<EntityStorage>().AsSingle();
        }
    }
}