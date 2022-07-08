using Codetox.Editor.Utils;
using Codetox.GameEvents;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.GameEvents
{
    public static class GameEventMenu
    {
        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Void, priority = -100)]
        public static void CreateVoidEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<VoidGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Bool, priority = -9)]
        public static void CreateBoolEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<BoolGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Float, priority = -8)]
        public static void CreateFloatEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<FloatGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Int, priority = -7)]
        public static void CreateIntEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<IntGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.String, priority = -6)]
        public static void CreateStringEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<StringGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Vector2, priority = -5)]
        public static void CreateVector2Event(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector2GameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Vector3, priority = -4)]
        public static void CreateVector3Event(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<Vector3GameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.GameObject, priority = 10)]
        public static void CreateGameObjectEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Component, priority = 11)]
        public static void CreateComponentEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<ComponentGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }

        [MenuItem("Tools/" + Framework.MenuRoot.GameEvents.Reference, priority = 12)]
        public static void CreateReferenceEvent(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<ReferenceGameEvent>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }
    }
}