using UnityEngine;

namespace Codetox.Input.InputActionHandlers
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Input.ActionHandlers.Float, fileName = nameof(FloatInputActionHandler))]
    public sealed class FloatInputActionHandler : InputActionHandler<float>
    {
    }
}