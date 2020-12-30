using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(Range))]
public class Range_PropertyDrawer : PropertyDrawer
{
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
		label = EditorGUI.BeginProperty(position, label, property);
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);
		contentPosition.width *= 0.5f;
		EditorGUI.indentLevel = 0;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("min"), GUIContent.none);
		contentPosition.x += contentPosition.width;
		EditorGUIUtility.labelWidth = 5f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("max"), new GUIContent("-"));
		EditorGUI.EndProperty();
	}
}