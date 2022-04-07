using System;
using System.Collections.Generic;
using Codetox.Core;
using JetBrains.Annotations;

namespace Codetox.Messaging
{
    public class Messenger : Singleton<Messenger>
    {
        private Dictionary<Type, object> _handlers;

        protected override void Init()
        {
            _handlers = new Dictionary<Type, object>();
        }

        public static void Subscribe<T>([NotNull] IMessageHandler<T> handler) where T : Message
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            if (!Instance) return;
            
            var messageType = typeof(T);

            if (Instance._handlers.TryGetValue(messageType, out var action))
            {
                Instance._handlers[messageType] = (Action<T>) action + handler.HandleMessage;
            }
            else
            {
                Instance._handlers[messageType] = (Action<T>) handler.HandleMessage;
            }
        }

        public static void UnSubscribe<T>([NotNull] IMessageHandler<T> handler) where T : Message
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            if (!Instance) return;
            
            var messageType = typeof(T);
            
            if (!Instance._handlers.TryGetValue(typeof(T), out var action)) return;
            
            Instance._handlers[messageType] = (Action<T>) action - handler.HandleMessage;
        }

        public static void Send<T>([NotNull] T message) where T : Message
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (!Instance) return;
            if (!Instance._handlers.TryGetValue(typeof(T), out var action)) return;
            
            ((Action<T>) action)?.Invoke(message);
        }
    }
}