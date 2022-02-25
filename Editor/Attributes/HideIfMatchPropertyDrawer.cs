using System.IO;
using System.Linq;
using Codetox.Attributes;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(HideIfMatchAttribute))]
    public class HideIfMatchPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            if (Hide(property)) return;
            EditorGUI.PropertyField(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Hide(property) ? 0f : base.GetPropertyHeight(property, label);
        }

        private bool Hide(SerializedProperty property)
        {
            var hideIfMatch = (HideIfMatchAttribute) attribute;
            var path = property.propertyPath.Contains(".")
                ? Path.ChangeExtension(property.propertyPath, hideIfMatch.Name)
                : hideIfMatch.Name;
            var serializedProperty = property.serializedObject.FindProperty(path);

            if (serializedProperty == null)
            {
                Debug.LogError("Cannot find property with name: " + path);
                return true;
            }

            var targetObject = serializedProperty.serializedObject.targetObject;
            var field = targetObject.GetType().GetField(serializedProperty.propertyPath);
            var value = field.GetValue(targetObject);

            return hideIfMatch.Values.Aggregate(false, (current, val) => current || value.Equals(val));
        }
    }
}