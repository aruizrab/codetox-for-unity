using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.String, fileName = nameof(StringVariable), order = -6)]
    public sealed class StringVariable : Variable<string>
    {
    }
}