using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(CraftManager))]

public class CraftManagerEditor : Editor
{
    private string[] tabs = { "Artifact", "ArtifactRecipe", "UI" };
    private int tabindex;
    private CraftManager craftManager;

    [Header("Artifact Recipe")]
    public SerializedProperty recipe;
    [Header("[Artifacts]")]
    private SerializedProperty resultArtifacts, artifactCount;

    [Header("UI")]
    public SerializedProperty craftWidget,content, slot, craftButton,exitButton,openButton;

    #region [EventFuction]
    private void OnEnable()
    {
        FindSerializedObject();
    }
    /*
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        craftManager = (CraftManager)target;

        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            tabindex = GUILayout.Toolbar(tabindex, tabs);
            switch (tabindex)
            {
                case 0:
                    TabArtifact();
                    break;
                case 1:
                    TabArtifactRecipe();
                    break;
                case 2:
                    TabUI();
                    break;

                default:
                    break;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }*/
    #endregion

    #region[FindDatas]
    private void FindSerializedObject()
    {
        //Artifact Recipe
        recipe = serializedObject.FindProperty("recipe");
        //Artifacts
        artifactCount = serializedObject.FindProperty("artifactCount");
        resultArtifacts = serializedObject.FindProperty("resultArtifacts");
        //UI
        craftWidget = serializedObject.FindProperty("craftWidget");
        content = serializedObject.FindProperty("content");
        slot = serializedObject.FindProperty("slot");
        craftButton = serializedObject.FindProperty("craftButton");
        exitButton = serializedObject.FindProperty("exitButton");
        openButton = serializedObject.FindProperty("openButton");
    }
    #endregion

    #region[Artifacts]
    private void TabArtifact()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(artifactCount);
            EditorGUI.indentLevel ++;
            EditorGUILayout.PropertyField(resultArtifacts);
            EditorGUI.indentLevel --;
        }
    }
    #endregion

    #region[ArifactRecipe]
    private void TabArtifactRecipe()
    {
        // VerticalScope를 EditorStyles.helpBox와 함께 사용
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(recipe);
        }
    }
    #endregion

    #region[UI]
    private void TabUI()
    {
        // VerticalScope를 EditorStyles.helpBox와 함께 사용
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(craftWidget);
            EditorGUILayout.PropertyField(content);
            EditorGUILayout.PropertyField(slot);
            EditorGUILayout.PropertyField(craftButton);
            EditorGUILayout.PropertyField(exitButton);
            EditorGUILayout.PropertyField(openButton);
        }
    }
    #endregion
}
