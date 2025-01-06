using System;
using System.Collections.Generic;

/**
 * 스킬 발동 조건을 모아둔 Enum
 */
public enum SkillActiveCond
{
    // TODO: 스킬 발동 조건추가
}

[Serializable]
public class Skill
{
    private string name;

    /**
     * 스킬 발동 조건 리스트
     */
    private List<SkillActiveCond> activeConds;
    
    private List<SkillEffect> effects;
}

public enum SkillEffectType
{
    // TODO: 스킬 효과 유형추가
}

[Serializable]
public class SkillEffect
{
    private SkillEffectType type;
    
    // TODO: 스킬 효과 효능 관련 변수추가

    public SkillEffect(SkillEffectType type)
    {
        this.type = type;
    }
}
