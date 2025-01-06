using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    private string entityName;
    private int level;

    private int curHp;
    private int maxHp;
    
    private int curStamina;
    private int maxStamina;
    
    // TODO: 스탯 관련 변수추가
    
    private List<Ability> abilities;
    private List<Skill> skills;
}
