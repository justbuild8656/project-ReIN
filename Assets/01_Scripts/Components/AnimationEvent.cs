using CameraSystem;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    #region [Animation_Event]
    public void Anim_on_Spell()
    {
        //CameraManager.Instance.ChangeCameraMode(CameraMode.Sequence);
        //CameraManager.Instance.SetSequenceData(sequenceData);
        
    }
    public void Anim_off_Spell()
    {
        CameraManager.Instance.ChangeCameraMode(CameraMode.Default);
        CameraManager.Instance.StartCoroutine(CameraManager.Instance.UpdateTransitionState());
    }
    #endregion

}
