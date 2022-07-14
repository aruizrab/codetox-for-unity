using Codetox.Editor.Utils;
using Codetox.RuntimeSets;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.RuntimeSets
{
    public static class RuntimeSetMenu
    {
        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.Bool, priority = -9)]
        public static void CreateScriptableBool(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<BoolRuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.Float, priority = -8)]
        public static void CreateScriptableFloat(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<FloatRuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.Int, priority = -7)]
        public static void CreateScriptableInt(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<IntRuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.String, priority = -6)]
        public static void CreateScriptableString(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<StringRuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.Vector2, priority = -5)]
        public static void CreateScriptableVector2(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector2RuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.Vector3, priority = -4)]
        public static void CreateScriptableVector3(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector3RuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.GameObject, priority = 10)]
        public static void CreateScriptableGameObject(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<GameObjectRuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.Component, priority = 11)]
        public static void CreateScriptableComponent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<ComponentRuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.RuntimeSets.Reference, priority = 12)]
        public static void CreateScriptableReference(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<ReferenceRuntimeSet>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }
    }
}