using Codetox.Editor.Utils;
using Codetox.Pooling;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.GameEvents
{
    public static class ObjectPoolMenu
    {
        [MenuItem("GameObject/" + Framework.MenuRoot.Pooling.GameObject)]
        [MenuItem("Tools/" + Framework.MenuRoot.Pooling.GameObject)]
        public static void CreateGameObjectPool(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<GameObjectPool>(command.context as GameObject);
        }

        [MenuItem("GameObject/" + Framework.MenuRoot.Pooling.ParticleSystem)]
        [MenuItem("Tools/" + Framework.MenuRoot.Pooling.ParticleSystem)]
        public static void CreateParticleSystemPool(MenuCommand command)
        {
            EditorHelper.CreateObjectOfType<ParticleSystemPool>(command.context as GameObject);
        }
    }
}