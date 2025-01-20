using UnityEngine;
using UnityEditor;
using System.Security.Cryptography;
[CustomEditor(typeof(SO_ArtifactRecipe))]
public class SO_ArtifactRecipeEditor : Editor
{
    private string[] tabs = { "ArtifactMaterials", "ResultArtifact"};
    private int tabindex;
    private SO_ArtifactRecipe recipe;

    [Header("[Result Artifact]")]
    private SerializedProperty resultArtifact;

    [Header("[Require Materials]")]
    private SerializedProperty reqMaterials;
    private void OnEnable()
    {
        FindSerializedObject();
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        recipe = (SO_ArtifactRecipe)target;
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            tabindex = GUILayout.Toolbar(tabindex, tabs);
            switch (tabindex)
            {
                case 0:
                    TabRequireMaterials();
                    break;
                case 1:
                    TabResultArtifact();
                    break;

                default:
                    break;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void FindSerializedObject()
    {
        resultArtifact = serializedObject.FindProperty("resultArtifact");
        reqMaterials = serializedObject.FindProperty("reqMaterials");
    }
    private void TabResultArtifact()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(resultArtifact);
            EditorGUI.indentLevel--;
        }
    }
    private void TabRequireMaterials()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(reqMaterials);
            EditorGUI.indentLevel--;
        }
    }
}
