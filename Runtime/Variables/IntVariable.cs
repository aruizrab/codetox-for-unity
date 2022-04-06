using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Int, fileName = nameof(IntVariable), order = -7)]
    public sealed class IntVariable : Variable<int>
    {
    }
}