using Codetox.Editor.Utils;
using Codetox.GameEvents;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.GameEvents
{
    public static class GameEventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Void, priority = -100)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Void, priority = -100)]
        public static void CreateVoidListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<VoidGameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Bool, priority = -9)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Bool, priority = -9)]
        public static void CreateBoolListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<BoolGameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Float, priority = -8)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Float, priority = -8)]
        public static void CreateFloatListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<FloatGameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Int, priority = -7)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Int, priority = -7)]
        public static void CreateIntListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<IntGameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.String, priority = -6)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.String, priority = -6)]
        public static void CreateStringListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<StringGameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Vector2, priority = -5)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Vector2, priority = -5)]
        public static void CreateVector2Listener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<Vector2GameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Vector3, priority = -4)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Vector3, priority = -4)]
        public static void CreateVector3Listener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<Vector3GameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.GameObject, priority = 10)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.GameObject, priority = 10)]
        public static void CreateGameObjectListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<GameObjectGameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Component, priority = 11)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Component, priority = 11)]
        public static void CreateComponentListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<ComponentGameEventListener>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.GameEventListeners.Reference, priority = 12)]
        [MenuItem(Framework.MenuRoot.GameEventListeners.Reference, priority = 12)]
        public static void CreateReferenceListener(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<ReferenceGameEventListener>(command.context as GameObject);
        }
    }
}