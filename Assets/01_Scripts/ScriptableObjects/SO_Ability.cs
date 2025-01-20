using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public enum AbilityType
{
    Heal01 = 0,
    SwordAttack01 = 1,
    ArrowAttack01 = 2,
}


[System.Serializable]
public struct AbilityAnimation
{
    [Header("[Ability Animation]")]
    public AnimationClip abilityClip;
    [Range(0.1f, 1f)]
    public float transitionDuration;
}
[System.Serializable]
public struct AbilityVFX
{
    [Header("[Ability VFX]")]
    public ParticleSystem particle;
    public Transform spawnSlot;
    public Vector3 spawnPosition;
    public bool isSpawn;

    public void SpawnVFX()
    {
        if (particle == null) { return; }
        if (isSpawn)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            UnityEngine.Object.Instantiate(particle, player.transform.position + spawnPosition, player.transform.rotation);
        }
    }
}

[System.Serializable]
public struct AbilitylData
{
    public AbilityType abilitype;
    public SO_Cam_SequenceData sequenceData;
}

[CreateAssetMenu(fileName = "SO_AbilityData", menuName = "Scriptable Objects/AbilityData")]

public class SO_Ability: ScriptableObject
{
    public AbilitylData data;
    public AbilityAnimation abilityAnimation;
    public AbilityVFX abilityVfx;
}
