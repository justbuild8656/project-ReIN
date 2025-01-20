using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(SO_Ability))]
public class SO_AbilityEditor : Editor
{
    private string[] tabs = { "Data", "Animation","Vfx" };
    private int tabindex;
    private SO_Ability ability;

    [Header("[Data]")]
    private SerializedProperty data;

    [Header("[Animation]")]
    private SerializedProperty abilityAnimation;

    [Header("Vfx")]
    private SerializedProperty abilityVfx;
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
                    TabAnimation();
                    break;

                case 2:
                    TabVfx();
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
        abilityAnimation = serializedObject.FindProperty("abilityAnimation");
        abilityVfx = serializedObject.FindProperty("abilityVfx");
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
    private void TabAnimation()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(abilityAnimation);
            EditorGUI.indentLevel--;
        }
    }
    private void TabVfx()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(abilityVfx);
            EditorGUI.indentLevel--;
        }
    }
}
