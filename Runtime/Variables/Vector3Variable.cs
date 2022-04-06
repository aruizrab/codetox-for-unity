using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Vector3, fileName = nameof(Vector3Variable), order = -4)]
    public sealed class Vector3Variable : Variable<Vector3>
    {
    }
}