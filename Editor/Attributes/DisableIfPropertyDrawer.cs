using System;
using System.IO;
using Codetox.Attributes;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DisableIfAttribute))]
    public class DisableIfPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            var guiState = GUI.enabled;
            GUI.enabled = Disable(property);
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = guiState;
        }

        private bool Disable(SerializedProperty property)
        {
            var showIf = (DisableIfAttribute) attribute;
            var path = property.propertyPath.Contains(".")
                ? Path.ChangeExtension(property.propertyPath, showIf.Name)
                : showIf.Name;
            var serializedProperty = property.serializedObject.FindProperty(path);

            if (serializedProperty == null)
            {
                Debug.LogError("Cannot find property with name: " + path);
                return true;
            }

            var targetObject = serializedProperty.serializedObject.targetObject;
            var field = targetObject.GetType().GetField(serializedProperty.propertyPath);
            var value = field.GetValue(targetObject);

            return CompareValues(showIf.Value, showIf.ComparisonType, value);
        }

        private bool CompareValues(object value1, ComparisonType comparisonType, object value2)
        {
            return comparisonType switch
            {
                ComparisonType.Equals => value1.Equals(value2),
                ComparisonType.NotEquals => !value1.Equals(value2),
                _ => CompareComparableValues(value1 as IComparable, comparisonType, value2 as IComparable)
            };
        }

        private bool CompareComparableValues(IComparable value1, ComparisonType comparisonType, IComparable value2)
        {
            if (value1 != null && value2 != null)
                return comparisonType switch
                {
                    ComparisonType.BiggerThan => value1.CompareTo(value2) < 0,
                    ComparisonType.BiggerEqualsThan => value1.CompareTo(value2) <= 0,
                    ComparisonType.LessThan => value1.CompareTo(value2) > 0,
                    ComparisonType.LessEqualsThan => value1.CompareTo(value2) >= 0
                };
            Debug.LogError("Property value cannot be compared by " + comparisonType);
            return true;
        }
    }
}