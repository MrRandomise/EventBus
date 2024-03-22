using JetBrains.Annotations;

namespace Logick
{
    [UsedImplicitly]
    public sealed class CurrentEntity
    {
        public EntityConfig Value { get; set; }
        
        public CurrentEntity()
        {
            Value = null;
        }
    }
}
