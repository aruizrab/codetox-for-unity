using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codetox.Variables
{
    [Serializable]
    public class VariableMap
    {
        [SerializeField] private Dictionary<string, VariableData> _map = new Dictionary<string, VariableData>();
	
        public void Load(List<BaseVariable> list)
        {
            _map.Clear();
            foreach (var variable in list)
            {
                _map.Add(variable.guid, variable.GetVariableData());
            }
        }

        public void Restore(List<BaseVariable> list)
        {
            foreach (var variable in list)
            {
                if (_map.TryGetValue(variable.guid, out var data))
                {
                    variable.LoadVariableData(data);
                }
            }
        }
    }
}