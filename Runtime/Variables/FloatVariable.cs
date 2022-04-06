using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Float, fileName = nameof(FloatVariable), order = -8)]
    public sealed class FloatVariable : Variable<float>
    {
    }
}