using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Color, fileName = nameof(ColorVariable), order = 30)]
    public sealed class ColorVariable : Variable<Color>
    {
    }
}