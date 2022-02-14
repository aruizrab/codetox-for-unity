using Codetox.Attributes;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfPropertyDrawer : PropertyDrawer
    {
        private ShowIfAttribute _attribute;
        private SerializedProperty _property;
        
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            if (!ShowAttribute(property)) return;
            EditorGUI.PropertyField(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return ShowAttribute(property) ? base.GetPropertyHeight(property, label) : 0f;
        }

        private bool ShowAttribute(SerializedProperty property)
        {
            _attribute = attribute as ShowIfAttribute;
            
            var path = property.propertyPath.Contains(".") ? System.IO.Path.ChangeExtension(property.propertyPath, _attribute.comparedPropertyName) : _attribute.comparedPropertyName;
            
            _property = property.serializedObject.FindProperty(path);
            
            if (_property == null)
            {
                Debug.LogError("Cannot find property with name: " + path);
                return true;
            }

            switch (_property.type)
            {
                case "bool":
                    return _property.boolValue.Equals(_attribute.comparedValue);
                case "Enum":
                    return _property.enumValueIndex.Equals((int) _attribute.comparedValue);
                default:
                    Debug.LogError("Error: " + _property.type + " is not supported of " + path);
                    return true;
            }
        }
    }
}