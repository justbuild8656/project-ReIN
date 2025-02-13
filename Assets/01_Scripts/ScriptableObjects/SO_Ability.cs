using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public enum AbilityType
{
    Heal01 = 0,
    SwordAttack01 = 1,
    ArrowAttack01 = 2,
}

[System.Serializable]
public struct TimelineData
{
    public TimelineAsset timelineAsset;
}

[CreateAssetMenu(fileName = "SO_AbilityData", menuName = "Scriptable Objects/AbilityData")]

public class SO_Ability: ScriptableObject
{
    //abilitydata
    public AbilityType abilityType;
    //timeline
    public TimelineData timelineData;
    //ui
    public Sprite buttonSprite;
}
