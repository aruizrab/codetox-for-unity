using Codetox.Editor.Utils;
using Codetox.Input;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Input
{
    public static class InputActionAssetRebindPersistenceManagerMenu
    {
        [MenuItem("Tools/" + Framework.MenuRoot.Input.ActionRebindPersistence.Path)]
        public static void CreateInputActionAssetRebindPersistenceManager(MenuCommand command)
        {
            var asset = ScriptableObject.CreateInstance<InputActionAssetRebindPersistenceManager>();
            EditorHelper.CreateAssetInSelectedPath(asset);
        }
    }
}