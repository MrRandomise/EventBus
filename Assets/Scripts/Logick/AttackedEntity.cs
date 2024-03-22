using JetBrains.Annotations;

namespace Logick
{
    [UsedImplicitly]
    public sealed class AttackedEntity
    {
        public EntityConfig Value { get; set; }
        
        public AttackedEntity()
        {
            Value = null;
        }
    }
}
