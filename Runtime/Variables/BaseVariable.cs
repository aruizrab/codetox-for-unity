using UnityEngine;

namespace Codetox.Variables
{
    public abstract class BaseVariable : CustomScriptableObject
    {
        [SerializeField] private bool persistent;
        [HideInInspector] public string guid;

        public bool Persistent => persistent;

        public abstract VariableData GetVariableData();
        public abstract void LoadVariableData(VariableData data);
    }
}