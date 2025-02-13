using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.MessageBox;
[CustomEditor(typeof(SO_Ability))]
public class SO_AbilityEditor : Editor
{
    private bool abilityTypeFoldout;
    private bool uiFoldout;
    private string[] tabs = { "Data","Timeline" };
    private int tabindex;
    private SO_Ability ability;

    private SerializedProperty abilityType, timelineData, buttonSprite;

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
        abilityType = serializedObject.FindProperty("abilityType");
        timelineData = serializedObject.FindProperty("timelineData");
        buttonSprite = serializedObject.FindProperty("buttonSprite");
    }
    private void TabData()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            abilityTypeFoldout = Foldout(abilityTypeFoldout, "[AbilityData]");
            if(abilityTypeFoldout)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(abilityType);
                EditorGUI.indentLevel--;
            }
            uiFoldout = Foldout(uiFoldout, "[UiData]");
            if (uiFoldout)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(buttonSprite);
                EditorGUI.indentLevel--;
            }
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

    static bool Foldout(bool display, string title)
    {
        var style = new GUIStyle("ShurikenModuleTitle");
        style.font = new GUIStyle(EditorStyles.boldLabel).font;
        style.fontSize = 12;
        style.border = new RectOffset(15, 7, 4, 4);
        style.fixedHeight = 22;
        style.contentOffset = new Vector2(20f, -2f);

        var rect = GUILayoutUtility.GetRect(16f, 22f, style);
        GUI.Box(rect, title, style);

        var e = Event.current;

        var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
        if (e.type == EventType.Repaint)
        {
            EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
        }

        if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
        {
            display = !display;
            e.Use();
        }

        return display;
    }
}
