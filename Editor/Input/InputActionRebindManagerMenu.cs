using Codetox.Editor.Utils;
using Codetox.Input;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Input
{
    public static class InputActionRebindManagerMenu
    {
        [MenuItem(Framework.MenuRoot.Input.ActionRebind.Path)]
        public static void CreateInputActionRebindManager(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<InputActionRebindManager>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }
    }
}