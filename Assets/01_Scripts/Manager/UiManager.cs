using CameraSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.Timeline;
public class UiManager : MonoBehaviour
{
    public AttributeManager attribute;
    // Test : ���� �����Ƽ�� ��ư üũ�ϱ� ���ؼ� �׽�Ʈ��
    //test
    public SO_Artifact[] artifactData;
    [SerializeField] PlayableDirector playableDirector;

    public Transform abilityParent;
    [Header("UI")]
    public GameObject abilityBtnPrefab;
    public Image healthBar;
    public TextMeshProUGUI health;
    public Image staminaBar;
    public TextMeshProUGUI heatPercent;

    #region[EventFuction]
    private void Awake()
    {
        InitAbilityButton();
        AddAttributeEvent();
    }
    #endregion

    #region [AttributeDelegate]
    private void AddAttributeEvent()
    {
        attribute.updateHealthValue += UpdateHealthValue;
        attribute.updateStaminaValue += UpdateStaminaValue;
        attribute.updateHeatValue += UpdateHeatValue;
    }

    #region[SetValue]
    //ü�� ��������Ʈ �Լ�
    private void UpdateHealthValue(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
        health.text = currentHealth.ToString();
    }
    //���׹̳� ��������Ʈ �Լ�
    private void UpdateStaminaValue(float currentStamina, float maxStamina)
    {
        staminaBar.fillAmount = (currentStamina / maxStamina);
    }
    //��Ʈ ��������Ʈ �Լ�
    private void UpdateHeatValue(float currentHeat)
    {
        //�Ҽ��� �����ϱ�
        int heatpercent = Mathf.FloorToInt(currentHeat);
        heatPercent.text = heatpercent.ToString() + "%";
    }
    #endregion

    #endregion

    #region [UI]

    private void InitAbilityButton()
    {
        for (int i = 0; i < artifactData.Length; i++)
        {
            int index = i;
            //��ư����
            GameObject abilityBtn = Instantiate(abilityBtnPrefab, abilityParent.transform.position, Quaternion.identity,abilityParent);
            //������ ��ư�� Ŭ�� �̺�Ʈ �߰�
            abilityBtn.GetComponent<Button>().onClick.AddListener(() => AbilityEvent(index));
            abilityBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = artifactData[i].ability.type.ToString();
            abilityBtn.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = artifactData[i].ability.data.staminaCost.ToString();
        }
    }
    private void AbilityEvent(int i)
    {
        //�������� Ÿ�ζ��� �ּ� �÷���
        if(artifactData[i].ability.timelineData.timelineAsset!=null)
        {
            if (playableDirector.state == PlayState.Playing) { return; }
            if (attribute.currentStamina <= artifactData[i].ability.data.staminaCost) { return; }

            playableDirector.Play(artifactData[i].ability.timelineData.timelineAsset);
            attribute.currentStamina -= artifactData[i].ability.data.staminaCost;
        }
    }
    #endregion
 
}
