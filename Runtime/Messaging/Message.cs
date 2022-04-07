using UnityEngine;

namespace Codetox.Messaging
{
    public abstract class Message
    {
        public readonly Component Sender;

        protected Message(Component sender)
        {
            Sender = sender;
        }
    }
}