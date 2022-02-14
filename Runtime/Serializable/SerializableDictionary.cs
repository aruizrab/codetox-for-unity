using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codetox.Serializable
{
    [Serializable]
    public class SerializableDictionary<TK, TV> : Dictionary<TK, TV>, ISerializationCallbackReceiver
    {
        [SerializeField] private KeyValue[] dictionary;

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            Clear();
            foreach (var kv in dictionary)
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
                (key, value) = pair;
            }
        }
    }
}