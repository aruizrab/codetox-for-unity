using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Reference, fileName = nameof(ReferenceVariable), order = 12)]
    public sealed class ReferenceVariable : Variable<Object>
    {
    }
}