using CameraSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.Timeline;
public class UiManager : MonoBehaviour
{
    // Test : 현재 어빌리티와 버튼 체크하기 위해서 테스트중
    
    public Animator animator;
    //test
    public SO_Artifact[] artifactData;
    [SerializeField] PlayableDirector playableDirector;
    public Button[] abilityBtn;

    private void Awake()
    {
        for (int i = 0; i < abilityBtn.Length; i++)
        {
            int index = i;
            abilityBtn[i].onClick.AddListener(() => SpellAnimation(index));
            abilityBtn[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = artifactData[i].artifactAbility.abilityType.ToString();
        }
    }
    #region [ComboComponent_Function(test)]
    public void SpellAnimation(int i)
    {
        if(artifactData[i].artifactAbility.timelineData.timelineAsset!=null)
        {
            if (playableDirector.state == PlayState.Playing) { return; }
            playableDirector.Play(artifactData[i].artifactAbility.timelineData.timelineAsset);
        }
    }
    /*
        animator.CrossFadeInFixedTime(artifactData[i].artifactAbility.abilityAnimation.abilityClip.name,
            artifactData[i].artifactAbility.abilityAnimation.transitionDuration);
        CameraManager.Instance.ChangeCameraMode(CameraMode.Sequence);
        CameraManager.Instance.SetSequenceData(artifactData[i].artifactAbility.data.sequenceData);
        artifactData[i].artifactAbility.abilityVfx.SpawnVFX();*/
    #endregion
}
