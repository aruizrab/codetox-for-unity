using System.Collections.Generic;
using System.Linq;
using Codetox.Variables;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Variables
{
    [CustomEditor(typeof(VariableManager))]
    public class VariableManagerCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!GUILayout.Button("Refresh")) return;

            var assets = AssetDatabase.FindAssets("t:BaseVariable").ToList();
            var variables = new List<BaseVariable>();

            foreach (var asset in assets)
            {
                var path = AssetDatabase.GUIDToAssetPath(asset);
                var variable = AssetDatabase.LoadAssetAtPath<BaseVariable>(path);

                if (!variable.Persistent) continue;
                if (string.IsNullOrEmpty(variable.guid)) variable.guid = asset;

                variables.Add(variable);
            }

            var manager = (VariableManager) target;

            manager.variables = variables;
        }
    }
}