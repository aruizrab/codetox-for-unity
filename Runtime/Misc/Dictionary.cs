using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codetox.Misc
{
    [Serializable]
    public class Dictionary<TK, TV> : System.Collections.Generic.Dictionary<TK, TV>, ISerializationCallbackReceiver
    {
        [SerializeField] private KeyValue[] items;

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            Clear();
            foreach (var kv in items)
                if (!ContainsKey(kv.key))
                    Add(kv.key, kv.value);
        }

        [Serializable]
        private struct KeyValue
        {
            public TK key;
            public TV value;

            public KeyValue(KeyValuePair<TK, TV> pair)
            {
                key = pair.Key;
                value = pair.Value;
            }
        }
    }
}