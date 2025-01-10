using LocomotionSystem;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private Animator animator;
    //test
    public SO_Skill skill_data;
    public SO_Cam_SequenceData sequenceData;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //test
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CameraManager.Instance.current_speed == 0.0f && CameraManager.Instance.transition_state != TransitionState.Transition)
            {
                Anim_on_Spell();
            }
            
        }
    }
    #region [ComboComponent_Function(test)]
    public void SpellAnimation(SO_Skill skill)
    {
        animator.CrossFadeInFixedTime(skill.skill_data.spell_clip.name, skill.skill_data.transition_duration);
    }
    #endregion

    #region [Animation_Event]
    public void Anim_on_Spell()
    {
        CameraManager.Instance.ChangeCameraMode(CameraMode.Sequence);
        CameraManager.Instance.SetSequenceData(sequenceData);
        SpellAnimation(skill_data);
    }
    public void Anim_off_Spell()
    {
        CameraManager.Instance.ChangeCameraMode(CameraMode.Targeting);
        CameraManager.Instance.StartCoroutine(CameraManager.Instance.UpdateTransitionState());
    }
    #endregion

}
