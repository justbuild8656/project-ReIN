using UnityEngine;

public enum SkillID
{
    Heal01 = 0,
    Heal02 = 1,
    SwordAttack01 = 2,
    SwordAttack02 = 3,
}

[CreateAssetMenu(fileName = "SO_Skill_data", menuName = "Scriptable Objects/Skill_data")]

public class SO_Skill: ScriptableObject
{
    [System.Serializable]
    public struct Skill_Data
    {
        public SkillID eskill_id;
        public string skill_id;
        public AnimationClip spell_clip;
        [Range(0.1f,1f)]
        public float transition_duration;
    }
    [Header("Skill_Data")]
    public Skill_Data skill_data;
   

    private void OnValidate()
    {
        skill_data.skill_id = skill_data.eskill_id.ToString();
    }
}
