using Codetox.Editor.Utils;
using Codetox.Input.InputActionHandlers;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Input
{
    public static class InputActionHandlerMenu
    {
        [MenuItem("Tools/" + Framework.MenuRoot.Input.ActionHandlers.Void, priority = -20)]
        public static void CreateVoidInputActionHandler(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<VoidInputActionHandler>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Input.ActionHandlers.Bool)]
        public static void CreateBoolInputActionHandler(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<BoolInputActionHandler>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Input.ActionHandlers.Float)]
        public static void CreateFloatInputActionHandler(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<FloatInputActionHandler>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Input.ActionHandlers.Vector2)]
        public static void CreateVector2InputActionHandler(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector2InputActionHandler>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Input.ActionHandlers.Vector3)]
        public static void CreateVector3InputActionHandler(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector3InputActionHandler>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }
    }
}