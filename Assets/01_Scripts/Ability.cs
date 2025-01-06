using System;
using System.Collections.Generic;

[Serializable]
public class Ability
{
    private string name;
    
    private int curCoolTime;
    private int maxCoolTime;
    
    /**
     * 어빌리티 사용 시간
     */
    private float castTime;
    
    /**
     * 피버 상태에서 어빌리티 사용시 저스트 타이밍 이벤트 발생.
     * 해당 타이밍에 다른 어빌리티 선택시 저스트 콤보 발동.
     * 피버 상태 지속시간 증가
     */
    private float justTime;
    
    private List<AbilityEffect> effects;
}

public enum AbilityEffectType
{
    // TODO: 어빌리티 효과 타입추가
}

[Serializable]
public class AbilityEffect
{
    private AbilityEffectType type;
    
    // TODO: 어빌리티 효과 효능 관련 변수추가

    public AbilityEffect(AbilityEffectType type)
    {
        this.type = type;
    }
}
