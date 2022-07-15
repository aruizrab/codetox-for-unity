using Codetox.Variables;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.Variables
{
    [CustomPropertyDrawer(typeof(ValueReference<>))]
    public class ValueReferencePropertyDrawer : PropertyDrawer
    {
        private readonly string[] _popupOptions = {"Use Field", "Use Variable"};
        
        private GUIStyle _popupStyle;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly
            };
            
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);
            
            EditorGUI.BeginChangeCheck();
            
            var useField = property.FindPropertyRelative("useField");
            var variableValue = property.FindPropertyRelative("variableValue");
            var fieldValue = property.FindPropertyRelative("fieldValue");
            
            var buttonRect = new Rect(position);
            buttonRect.yMin += _popupStyle.margin.top;
            buttonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right;
            position.xMin = buttonRect.xMax;
            
            var indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            var result = EditorGUI.Popup(buttonRect, useField.boolValue ? 0 : 1, _popupOptions, _popupStyle);
            
            useField.boolValue = result == 0;
            
            EditorGUI.PropertyField(position, useField.boolValue ? fieldValue : variableValue, GUIContent.none);
            
            if (EditorGUI.EndChangeCheck()) property.serializedObject.ApplyModifiedProperties();
            
            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }
    }
}