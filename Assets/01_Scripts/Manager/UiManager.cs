using CameraSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class UiManager : MonoBehaviour
{
    // Test : ���� �����Ƽ�� ��ư üũ�ϱ� ���ؼ� �׽�Ʈ��
    
    public Animator animator;
    //test
    public SO_Artifact[] artifactData;
    [SerializeField] PlayableDirector playableDirector;
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
        playableDirector.Play(artifactData[i].artifactAbility.timelineData.timelineAsset);
    }
    /*
        animator.CrossFadeInFixedTime(artifactData[i].artifactAbility.abilityAnimation.abilityClip.name,
            artifactData[i].artifactAbility.abilityAnimation.transitionDuration);
        CameraManager.Instance.ChangeCameraMode(CameraMode.Sequence);
        CameraManager.Instance.SetSequenceData(artifactData[i].artifactAbility.data.sequenceData);
        artifactData[i].artifactAbility.abilityVfx.SpawnVFX();*/
    #endregion
}
