namespace Logick.HeroesSkills
{
    public abstract class BaseSkills
    { 
        public abstract void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage);
    }
}
