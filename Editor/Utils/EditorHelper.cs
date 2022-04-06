using System.IO;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Utils
{
    public static class EditorHelper
    {
        public static void CreateAssetInSelectedPath(Object asset)
        {
            var path = "Assets";
            
            foreach (var o in Selection.GetFiltered<Object>(SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(o);
                if (File.Exists(path)) path = Path.GetDirectoryName(path);
                break;
            }

            path += $"/{asset.GetType().Name}.asset";
            ProjectWindowUtil.CreateAsset(asset, path);
        }

        public static void CreateObjectOfType<T>(GameObject parent) where T: Component
        {
            var obj = new GameObject(ObjectNames.NicifyVariableName(typeof(T).Name));
            obj.AddComponent<T>();
            GameObjectUtility.SetParentAndAlign(obj, parent);
            Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            Selection.activeObject = obj;
        }
    }
}