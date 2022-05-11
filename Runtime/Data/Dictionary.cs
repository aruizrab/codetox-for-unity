using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Codetox.Data
{
    [Serializable]
    public class Dictionary<TK, TV> : System.Collections.Generic.Dictionary<TK, TV>, ISerializationCallbackReceiver
    {
        [SerializeField] private List<KeyValue> dictionary;

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            Clear();
            foreach (var pair in dictionary.Where(pair => !ContainsKey(pair.key))) Add(pair.key, pair.value);
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