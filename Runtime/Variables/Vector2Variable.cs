using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Vector2, fileName = nameof(Vector2Variable), order = -5)]
    public sealed class Vector2Variable : Variable<Vector2>
    {
    }
}