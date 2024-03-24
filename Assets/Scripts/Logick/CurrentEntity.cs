namespace Logick
{
    public sealed class CurrentEntity
    {
        public EntityConfig Value { get; set; }
        
        public CurrentEntity()
        {
            Value = null;
        }
    }
}
