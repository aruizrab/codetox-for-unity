using UnityEngine;

namespace Codetox.Input.InputActionHandlers
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Input.ActionHandlers.Vector3, fileName = nameof(Vector3InputActionHandler))]
    public sealed class Vector3InputActionHandler : InputActionHandler<Vector3>
    {
    }
}