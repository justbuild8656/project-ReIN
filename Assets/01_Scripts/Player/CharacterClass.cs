using System;
using System.Collections.Generic;

[Serializable]
public class CharacterClass
{
    int id;                 // 클래스 ID
    int strengthWeight;     // 완력 가중치
    int intelligenceWeight; // 지력 가중치
    int staminaWeight;      // 견고 가중치
    int enduranceWeight;    // 지구 가중치
    int intuitionWeight;    // 직감 가중치
    
    private List<Ability> abilities; // 어빌리티 리스트
    private List<Skill> skills;      // 스킬 리스트
}
