using UnityEngine;
using UnityEditor;
using UnityEngine.Splines;
[CustomEditor(typeof(SO_Cam_SequenceData))]
public class SO_Cam_SequenceDataEditor : Editor
{
    private SO_Cam_SequenceData sequenceData;

    [Header("Prefab_Data_Setting")]
    private SerializedProperty use_prefab_spline_setting;
    private SerializedProperty container;
    [Header("Speed_Parameter")]
    private SerializedProperty cart_speed;
    [Header("Spline_Data")]
    private SerializedProperty waypoints;
    private void OnEnable()
    {
        FindSerializedObject();
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        sequenceData = (SO_Cam_SequenceData)target;
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            Speed_Parameter();
            Prefab_Data_Setting();
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                Spline_Data();
            }
        }
        
        serializedObject.ApplyModifiedProperties();
    }
    private void FindSerializedObject()
    {
        use_prefab_spline_setting = serializedObject.FindProperty("use_prefab_spline_setting");
        container = serializedObject.FindProperty("container");
        cart_speed = serializedObject.FindProperty("cart_speed");
        waypoints = serializedObject.FindProperty("waypoints");
    }

    #region[PrefabDataSetting]
    private void Prefab_Data_Setting()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(use_prefab_spline_setting);
            if(sequenceData.waypoints.Count<=0&&sequenceData.use_prefab_spline_setting)
            {
                EditorGUILayout.PropertyField(container);
                EditorGUILayout.HelpBox("A Prefab Spline Data is required in the sequence data", MessageType.Warning);
            }
        }
    }
    #endregion

    #region[Speed_Parameter]
    private void Speed_Parameter()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(cart_speed);
        }
    }
    #endregion

    #region[Spline Data]
    private void Spline_Data()
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(waypoints);
            EditorGUI.indentLevel--;
        }
    }
    #endregion
}
