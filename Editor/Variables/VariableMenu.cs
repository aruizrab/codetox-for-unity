using Codetox.Editor.Utils;
using Codetox.Variables;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Variables
{
    public static class VariableMenu
    {
        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Bool, priority = -9)]
        public static void CreateScriptableBool(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<BoolVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Float, priority = -8)]
        public static void CreateScriptableFloat(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<FloatVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Int, priority = -7)]
        public static void CreateScriptableInt(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<IntVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.String, priority = -6)]
        public static void CreateScriptableString(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<StringVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Vector2, priority = -5)]
        public static void CreateScriptableVector2(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector2Variable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Vector3, priority = -4)]
        public static void CreateScriptableVector3(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector3Variable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.GameObject, priority = 10)]
        public static void CreateScriptableGameObject(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<GameObjectVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Component, priority = 11)]
        public static void CreateScriptableComponent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<ComponentVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Reference, priority = 12)]
        public static void CreateScriptableReference(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<ReferenceVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.Color, priority = 30)]
        public static void CreateScriptableColor(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<ColorVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.Variables.LayerMask, priority = 31)]
        public static void CreateScriptableLayerMask(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<LayerMaskVariable>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }
    }
}