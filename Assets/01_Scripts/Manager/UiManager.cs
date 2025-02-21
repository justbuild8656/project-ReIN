using CameraSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.Timeline;
public class UiManager : MonoBehaviour
{
    public AttributeManager attribute;
    // Test : 현재 어빌리티와 버튼 체크하기 위해서 테스트중
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
    //체력 델리게이트 함수
    private void UpdateHealthValue(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
        health.text = currentHealth.ToString();
    }
    //스테미나 델리게이트 함수
    private void UpdateStaminaValue(float currentStamina, float maxStamina)
    {
        staminaBar.fillAmount = (currentStamina / maxStamina);
    }
    //히트 델리게이트 함수
    private void UpdateHeatValue(float currentHeat)
    {
        //소수점 삭제하기
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
            //버튼생성
            GameObject abilityBtn = Instantiate(abilityBtnPrefab, abilityParent.transform.position, Quaternion.identity,abilityParent);
            //생성된 버튼에 클릭 이벤트 추가
            abilityBtn.GetComponent<Button>().onClick.AddListener(() => AbilityEvent(index));
            abilityBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = artifactData[i].ability.type.ToString();
            abilityBtn.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = artifactData[i].ability.data.staminaCost.ToString();
        }
    }
    private void AbilityEvent(int i)
    {
        //마도구의 타인라인 애셋 플레이
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
