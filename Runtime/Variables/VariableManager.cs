using System.Collections.Generic;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Manager, fileName = nameof(VariableManager), order = -20)]
    public class VariableManager : CustomScriptableObject
    {
        public List<BaseVariable> variables;
    }
}