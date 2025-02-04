using CameraSystem;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    // Test : 현재 어빌리티와 버튼 체크하기 위해서 테스트중
    
    public Animator animator;
    //test
    public SO_Artifact[] artifactData;
    public Button[] abilityBtn;
    public System.Action<int> onClick;
    public bool reinforced;
    private int currentindex;
    private void Awake()
    {
        for (int i = 0; i < abilityBtn.Length; i++)
        {
            int index = i;
            abilityBtn[i].onClick.AddListener(() => SpellAnimation(index));
        }
    }
    #region [ComboComponent_Function(test)]
    public void SpellAnimation(int i)
    {
        animator.CrossFadeInFixedTime(artifactData[i].artifactAbility.abilityAnimation.abilityClip.name,
            artifactData[i].artifactAbility.abilityAnimation.transitionDuration);
        CameraManager.Instance.ChangeCameraMode(CameraMode.Sequence);
        CameraManager.Instance.SetSequenceData(artifactData[i].artifactAbility.data.sequenceData);
        artifactData[i].artifactAbility.abilityVfx.SpawnVFX();
    }
    #endregion
}
