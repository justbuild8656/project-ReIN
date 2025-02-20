using System.Collections;
using UnityEngine;
using Unity.Cinemachine;
using System;
namespace CameraSystem
{
    public enum CameraMode
    {
        Default,
    }
    public enum TransitionState
    {
        None,
        Transition,
    }
    [System.Serializable]

    public class CameraManager : MonoBehaviour
    {
        public CinemachineTargetGroup targetGroup;
        private static CameraManager instance;
        public static CameraManager Instance { get => instance; }
        //camera_transition_state
        [Header("Transition_State")]
        public TransitionState transitionState = TransitionState.None;

        //camera_mode
        [Header("Camera_Mode")]
        public CameraMode cameraMode = CameraMode.Default;

        //default,cutscene,target
        [Header("Cinemachine_Cameras")]
        [SerializeField] CinemachineCamera camDefault;

        //cameraShake_Component
        private CinemachineImpulseSource source;

        private void Awake()
        {
            Initialize();
        }
        private void Update()
        {
            //TestInput();
        }
        // Test:이후에 코드 삭제할 예정
        private void TestInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeCameraMode(CameraMode.Default);
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                CamreaShake();
            }
        }
        public void SetTargetGroup(Transform enemyTransform)
        {
            if(enemyTransform!=null)
            {
                targetGroup.AddMember(enemyTransform, 0.2f, 0.0f);
                targetGroup.Targets[1].Weight = 0.4f;
            }
        }
        public void UpdateTargetGroup(int index)
        {
            for(int i=0;i<targetGroup.Targets.Count;i++)
            {
                targetGroup.Targets[i].Weight = 0.2f;
            }
            targetGroup.Targets[0].Weight = 1f;
            targetGroup.Targets[index].Weight = 0.4f;
        }

        #region[Set Data]
        private void Initialize()
        {
            instance = this;

            //get_component
            source = Camera.main.gameObject.GetComponent<CinemachineImpulseSource>();
            DebugComponent();

            //init_setting
            cameraMode = CameraMode.Default;
            ChangeCameraMode(cameraMode);
        }
        public void ChangeCameraMode(CameraMode p_camera_mode)
        {
            cameraMode = p_camera_mode;
            switch (cameraMode)
            {
                case CameraMode.Default:
                    camDefault.Priority = 10;
                    break;
            }
        }
        #endregion

        #region [Transition] 
        public IEnumerator UpdateTransitionState()
        {
            transitionState = TransitionState.Transition;
            yield return new WaitForSeconds(0.7f);
            transitionState = TransitionState.None;

        }

        #endregion

        #region[Default]

        #endregion

        #region[Camera_Shake]
        public void CamreaShake()
        {
            if (source == null) { return; }
            source.GenerateImpulse();
        }
        #endregion

        #region [Debugger]
        private void DebugComponent()
        {
            if (source == null)
            {
                Debug.LogWarning("CinemachineImpulseSource is required in the main camera");
            }
        }

        private void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            style.fontSize = 16;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0f,0f,100f,100f),"[camera_mode]:"+ cameraMode.ToString(),style);
            //GUI.Label(new Rect(30f, 1 * 18f, 100f, 100f), "[speed]-sequence-data:" + string.Format("{0:N4}", sequenceData.cart_speed), style);
        }
        #endregion
    }
}