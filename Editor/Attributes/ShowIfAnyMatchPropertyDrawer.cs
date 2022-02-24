using System.IO;
using System.Linq;
using Codetox.Attributes;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(ShowIfAnyMatchAttribute))]
    public class ShowIfAnyMatchPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            if (!Show(property)) return;
            EditorGUI.PropertyField(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Show(property) ? base.GetPropertyHeight(property, label) : 0f;
        }

        private bool Show(SerializedProperty property)
        {
            var showIfMatch = (ShowIfAnyMatchAttribute) attribute;
            var path = property.propertyPath.Contains(".")
                ? Path.ChangeExtension(property.propertyPath, showIfMatch.Name)
                : showIfMatch.Name;
            var serializedProperty = property.serializedObject.FindProperty(path);
            
            if (serializedProperty == null)
            {
                Debug.LogError("Cannot find property with name: " + path);
                return true;
            }
            
            var targetObject = serializedProperty.serializedObject.targetObject;
            var field = targetObject.GetType().GetField(serializedProperty.propertyPath);
            var value = field.GetValue(targetObject);

            return showIfMatch.Values.Aggregate(false, (current, val) => current || value.Equals(val));
        }
    }
}