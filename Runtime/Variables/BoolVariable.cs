using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Bool, fileName = nameof(BoolVariable), order = -9)]
    public sealed class BoolVariable : Variable<bool>
    {
    }
}