using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.LayerMask, fileName = nameof(LayerMaskVariable), order = 31)]
    public sealed class LayerMaskVariable : Variable<LayerMask>
    {
    }
}