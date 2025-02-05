using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(SO_Ability))]
public class SO_AbilityEditor : Editor
{
    private string[] tabs = { "Data","Timeline" };
    private int tabindex;
    private SO_Ability ability;

    private SerializedProperty data,timelineData;

    private void OnEnable()
    {
        FindSerializedObject();
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ability = (SO_Ability)target;
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            tabindex = GUILayout.Toolbar(tabindex, tabs);
            switch (tabindex)
            {
                case 0:
                    TabData();
                    break;
                case 1:
                    TabTimeline();
                    break;
                default:
                    break;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void FindSerializedObject()
    {
        data = serializedObject.FindProperty("data");
        timelineData = serializedObject.FindProperty("timelineData");
    }
    private void TabData()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(data);
            EditorGUI.indentLevel--;
        }
    }
    private void TabTimeline()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(timelineData);
            EditorGUI.indentLevel--;
        }
    }
}
