using System;

namespace Logick
{
    public sealed partial class EventBus
    {
        private interface IEventHandlerCollection
        {
            public void Subscribe(Delegate handler);
            
            public void Unsubscribe(Delegate handler);
            
            public void RaiseEvent<T>(T evt);
        }
    }
}
