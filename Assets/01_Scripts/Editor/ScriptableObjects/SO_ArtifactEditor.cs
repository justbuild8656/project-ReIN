using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(SO_Artifact))]
public class SO_ArtifactEditor : Editor
{
    private string[] tabs = { "Data", "Ability" };
    private int tabindex;
    private SO_Artifact artifact;

    [Header("Artifact Info")]
    private SerializedProperty artifactInfo;
    [Header("[Region Type]")]
    private SerializedProperty regionType;
    [Header("[Artifact Weight Value]")]
    private SerializedProperty weightSetting;
    [Header("[Ability]")]
    private SerializedProperty ability;
    private void OnEnable()
    {
        FindSerializedObject();
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        artifact = (SO_Artifact)target;
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            tabindex = GUILayout.Toolbar(tabindex, tabs);
            switch (tabindex)
            {
                case 0:
                    TabData();
                    break;
                case 1:
                    TabAbility();
                    break;

                default:
                    break;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void FindSerializedObject()
    {
        artifactInfo = serializedObject.FindProperty("artifactInfo");
        regionType = serializedObject.FindProperty("regionType");
        weightSetting = serializedObject.FindProperty("weightSetting");
        ability = serializedObject.FindProperty("ability");
    }
    #region [Artifact Data]
    private void TabData()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.PropertyField(regionType);
            }
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(artifactInfo);
                EditorGUI.indentLevel--;
            }
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(weightSetting);
                EditorGUI.indentLevel--;
            }
        }
    }
    #endregion

    #region [Artifact Ability]
    private void TabAbility()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(ability);
        }
    }
    #endregion
}
