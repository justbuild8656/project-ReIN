using System.Collections.Generic;
using System;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;
[System.Flags]
public enum AttributeType
{
    Health = 1<<0,
    Stamina = 1<<2,
    Heat = 1<<3,
}


public class AttributeManager : MonoBehaviour
{
    public AttributeType attributeType;

    private float maxhealth;
    [Range(0.0f,9999.0f)]
    public float currentHealth;
    
    private float maxstamina;
    [Range(0.0f, 99.0f)]
    public float currentStamina;
    
    private float maxheat;
    [Range(0.0f, 99.0f)]
    public float currentHeat;

    //ui 델리게이트
    public delegate void UpdateHealthValue(float currentHealth,float maxHealth);
    public event UpdateHealthValue updateHealthValue;

    public delegate void UpdateStaminaValue(float currentStamina,float maxStamina);
    public event UpdateStaminaValue updateStaminaValue;

    public delegate void UpdateHeatValue(float currentHeat);
    public event UpdateHeatValue updateHeatValue;
    
    private void Awake()
    {
        InitAttribute(attributeType);
    }
    private void Update()
    {
        updateHeatValue?.Invoke(currentHeat);
        updateHealthValue?.Invoke(currentHealth, maxhealth);
        updateStaminaValue?.Invoke(currentStamina, maxstamina);
    }
    #region[SetData]
    public void InitAttribute(AttributeType type)
    {
        //플래그 이용해서 중복체크 가능
        foreach (AttributeType flag in Enum.GetValues(typeof(AttributeType)))
        {
            if ((type & flag) == flag)
            {
                switch (flag)
                {
                    case AttributeType.Health:
                        SetAttribute(AttributeType.Health);
                        break;

                    case AttributeType.Stamina:
                        SetAttribute(AttributeType.Stamina);
                        break;
                    case AttributeType.Heat:
                        SetAttribute(AttributeType.Heat);
                        break;
                }
            }
        }
    }
    private void SetAttribute(AttributeType attributeType)
    {
        switch (attributeType)
        {
            case AttributeType.Health:
                maxhealth = 9999.0f;
                currentHealth = maxhealth;
                break;

            case AttributeType.Stamina:
                maxstamina = 99.0f;
                currentStamina = maxstamina;
                break;
            case AttributeType.Heat:
                maxheat = 99.0f;
                currentHeat = maxheat;
                break;
        }
    }
    #endregion
}
