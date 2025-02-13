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

    public float maxhealth;
    public float currentHealth;
    public float maxstamina;
    public float currentStamina;
    public float maxheat;
    public float currentHeat;


    private void Awake()
    {
        InitAttribute(attributeType);
    }
    public void InitAttribute(AttributeType type)
    {
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
                maxhealth = 100.0f;
                currentHealth = maxhealth;
                break;

            case AttributeType.Stamina:
                maxstamina = 100.0f;
                currentStamina = maxstamina;
                break;
            case AttributeType.Heat:
                maxheat = 100.0f;
                currentHeat = maxheat;
                break;
        }
    }

}
