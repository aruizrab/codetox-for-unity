using Codetox.Misc;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.codetox_for_unity.Editor.Misc
{
    [CustomPropertyDrawer(typeof(Range<>))]
    public class RangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            label = EditorGUI.BeginProperty(position, label, property);
            
            var contentPosition = EditorGUI.PrefixLabel(position, label);
            
            if (position.height > 18f) {
                position.height = 18f;
                EditorGUI.indentLevel += 1;
                contentPosition = EditorGUI.IndentedRect(position);
                contentPosition.y += 20f;
            }

            var width1 = contentPosition.width * 0.5f - 5f;
            var width2 = contentPosition.width * 0.5f;
            
            contentPosition.width = width1;

            EditorGUI.indentLevel = 0;
            
            EditorGUIUtility.labelWidth = 25f;
            EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("min"), new GUIContent("Min"));
            
            contentPosition.x += width1 + 5f;
            contentPosition.width = width2;
            
            EditorGUIUtility.labelWidth = 30f;
            EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("max"), new GUIContent("Max"));
            
            EditorGUI.EndProperty();
        }
        
        public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
            return Screen.width < 414 ? (18f + 20f) : 18f;
        }
    }
}