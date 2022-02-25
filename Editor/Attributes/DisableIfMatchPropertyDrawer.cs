using System.IO;
using System.Linq;
using Codetox.Attributes;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DisableIfMatchAttribute))]
    public class DisableIfMatchPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            var guiState = GUI.enabled;
            GUI.enabled = !Disable(property);
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = guiState;
        }

        private bool Disable(SerializedProperty property)
        {
            var disableIfMatch = (DisableIfMatchAttribute) attribute;
            var path = property.propertyPath.Contains(".")
                ? Path.ChangeExtension(property.propertyPath, disableIfMatch.Name)
                : disableIfMatch.Name;
            var serializedProperty = property.serializedObject.FindProperty(path);

            if (serializedProperty == null)
            {
                Debug.LogError("Cannot find property with name: " + path);
                return true;
            }

            var targetObject = serializedProperty.serializedObject.targetObject;
            var field = targetObject.GetType().GetField(serializedProperty.propertyPath);
            var value = field.GetValue(targetObject);

            return disableIfMatch.Values.Aggregate(false, (current, val) => current || value.Equals(val));
        }
    }
}