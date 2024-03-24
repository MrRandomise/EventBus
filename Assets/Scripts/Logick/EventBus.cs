using System;
using System.Collections.Generic;
using Logick.Events;
using UnityEngine;

namespace Logick
{
    public sealed partial class EventBus
    {
        private readonly Dictionary<Type, IEventHandlerCollection> _handlers = new();

        private readonly Queue<IEvent> _queue = new();

        private bool _isRunning;
        
        public void Subscribe<T>(Action<T> handler)
        {
            Type eventType = typeof(T);

            if (!_handlers.ContainsKey(eventType))
            {
                _handlers.Add(eventType, new EventHandlerCollection<T>());
            }
            
            _handlers[eventType].Subscribe(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            Type eventType = typeof(T);

            if (_handlers.TryGetValue(eventType, out IEventHandlerCollection handlers))
            {
                handlers.Unsubscribe(handler);
            }
        }

        public void RaiseEvent<T>(T evt) where T : IEvent
        {
            if (_isRunning)
            {
                _queue.Enqueue(evt);
                return;
            }
            
            _isRunning = true;
            
            Type eventType = evt.GetType();

            if (!_handlers.TryGetValue(eventType, out var handlers))
            {
                Debug.Log($"No subscribers found in: {eventType}");
                _isRunning = false;
                return;
            }

            handlers.RaiseEvent(evt);

            _isRunning = false;

            if (_queue.TryDequeue(out var result))
            {
                RaiseEvent(result);
            }
        }
    }
}
