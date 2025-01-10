using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Splines;

[CreateAssetMenu(fileName = "SO_Cam_SequenceData", menuName = "Scriptable Objects/SequenceData")]
public class SO_Cam_SequenceData : ScriptableObject
{
    [Header("Prefab_Data_Setting")]
    public bool use_prefab_spline_setting;
    public SplineContainer container;
    [Header("Speed_Parameter")]
    [Range(0.0f,100.0f)]
    public float cart_speed;
    [Header("Spline_Data")]
    public Spline waypoints;
    public void OnValidate()
    {
        UpdatePrefabData();
    }
    private void UpdatePrefabData()
    {
        if (use_prefab_spline_setting)
        {
            if (container != null && use_prefab_spline_setting)
            {
                waypoints = container.Spline;
            }
            else
            {
                if (waypoints.Count > 0) { return; }
                Debug.LogWarning("A Prefab Spline Data is required in the sequence data");
            }
        }
        else
        {
            waypoints = null;
        }
    }

}
