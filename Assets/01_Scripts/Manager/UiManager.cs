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
    
    private void Awake()
    {
        InitAbilityButton();
        attribute.updateHealthValue += UpdateHealthValue;
        attribute.updateStaminaValue += UpdateStaminaValue;
        attribute.updateHeatValue += UpdateHeatValue;
    }
    #region [UI]
    private void InitAbilityButton()
    {
        for (int i = 0; i < artifactData.Length; i++)
        {
            int index = i;
            GameObject abilityBtn = Instantiate(abilityBtnPrefab, abilityParent.transform.position, Quaternion.identity,abilityParent);
            abilityBtn.GetComponent<Button>().onClick.AddListener(() => AbilityEvent(index));
            abilityBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = artifactData[i].ability.type.ToString();
            abilityBtn.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = artifactData[i].ability.data.staminaCost.ToString();
        }
    }
    private void AbilityEvent(int i)
    {
        if(artifactData[i].ability.timelineData.timelineAsset!=null)
        {
            if (playableDirector.state == PlayState.Playing) { return; }
            if (attribute.currentStamina <= artifactData[i].ability.data.staminaCost) { return; }

            playableDirector.Play(artifactData[i].ability.timelineData.timelineAsset);
            attribute.currentStamina -= artifactData[i].ability.data.staminaCost;
        }
    }
    private void UpdateHealthValue(float currentHealth,float maxHealth)
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
        health.text = currentHealth.ToString();
    }
    private void UpdateStaminaValue(float currentStamina,float maxStamina)
    { 
        staminaBar.fillAmount = (currentStamina / maxStamina);
    }
    private void UpdateHeatValue(float currentHeat)
    {
        int heatpercent = Mathf.FloorToInt(currentHeat);
        heatPercent.text = heatpercent.ToString() + "%";
    }
    #endregion
}
