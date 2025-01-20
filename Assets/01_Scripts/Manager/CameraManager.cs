using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.Cinemachine;
using UnityEngine.Splines;
using NUnit.Framework.Internal;
namespace CameraSystem
{
    public enum CameraMode
    {
        Default,
        Sequence,
        Targeting,
    }
    public enum TransitionState
    {
        None,
        Transition,
    }
    public class CameraManager : MonoBehaviour
    {
        private static CameraManager instance;
        public static CameraManager Instance { get => instance; }
        //camera_transition_state
        [Header("[Transition_State]")]
        public TransitionState transitionState = TransitionState.None;

        //camera_mode
        [Header("[Camera_Mode]")]
        public CameraMode cameraMode = CameraMode.Default;

        //default,cutscene,target
        [Header("[Cinemachine_Cameras]")]
        [SerializeField] CinemachineCamera camDefault;
        [SerializeField] CinemachineCamera camSequence;
        [SerializeField] CinemachineCamera camTargeting;

        //cameraShake_Component
        private CinemachineImpulseSource source;

        [Header("[Cinemachine_Sequence]")]
        public SplineContainer splineContainer;
        //public SO_Cam_SequenceData sequenceData;
        private CinemachineSplineDolly cart;

        //camera_parameter
        [Header("[Camera_Paramter]")]
        public float currentSpeed;
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
                var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
                if (autodolly != null)
                {
                    currentSpeed = 0.0f;
                    autodolly.Speed = currentSpeed;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(currentSpeed != 0.0f|| transitionState != TransitionState.Transition)
                {
                    ChangeCameraMode(CameraMode.Sequence);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeCameraMode(CameraMode.Targeting);
                
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                CamreaShake();
            }
        }
        private void Initialize()
        {
            instance = this;

            //get_component
            source = Camera.main.gameObject.GetComponent<CinemachineImpulseSource>();
            if(source==null)
            {
                Debug.LogWarning("CinemachineImpulseSource is required in the main camera");
            }
            cart = camSequence.GetComponent<CinemachineSplineDolly>();

            //init_setting
            cameraMode = CameraMode.Default;
            cart.CameraPosition = 0.0f;
            var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
            if (autodolly != null)
            {
                currentSpeed = 0.0f;
                autodolly.Speed = currentSpeed;
            }
            ChangeCameraMode(cameraMode);

            
        }
        public void ChangeCameraMode(CameraMode p_camera_mode)
        {
            cameraMode = p_camera_mode;
            switch (cameraMode)
            {
                case CameraMode.Default:
                    camDefault.Priority = 10;
                    camSequence.Priority = 0;
                    camTargeting.Priority = 0;
                    break;
                case CameraMode.Sequence:
                    camDefault.Priority = 0;
                    camSequence.Priority = 10;
                    camTargeting.Priority = 0;
                    break;
                case CameraMode.Targeting:
                    camDefault.Priority = 0;
                    camSequence.Priority = 0;
                    camTargeting.Priority = 10;
                    break;
            }

        }

        #region [Transition] 
        public IEnumerator UpdateTransitionState()
        {
            transitionState = TransitionState.Transition;
            yield return new WaitForSeconds(0.7f);
            transitionState = TransitionState.None;
            cart.CameraPosition = 0.0f;//reset CameraSpline
            var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
            if (autodolly != null)
            {
                currentSpeed = 0.0f;
                autodolly.Speed = currentSpeed;
            }
        }

        #endregion

        #region[Default]

        #endregion

        #region [Sequence]

        public void SetSequenceData(SO_Cam_SequenceData sequence_data)
        {
            cart.CameraPosition = 0.0f;//reset CameraSpline
            var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
            if (autodolly != null)
            {
                currentSpeed = sequence_data.cart_speed;
                autodolly.Speed = currentSpeed;
            }
            splineContainer.Spline = sequence_data.waypoints;
        }
        #endregion

        #region[Targeting]
        public void SetCameraTargetPosition(Vector3 target_position,Quaternion target_rotation)
        {
            camTargeting.transform.position = target_position;
            camTargeting.transform.rotation = target_rotation;
        }
        #endregion

        #region[Camera_Shake]
        public void CamreaShake()
        {
            if (source == null) { return; }
            source.GenerateImpulse();
        }
        #endregion

        #region [Debugger]
        private void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            style.fontSize = 16;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0f,0f,100f,100f),"[camera_mode]:"+ cameraMode.ToString(),style);
            //GUI.Label(new Rect(30f, 1 * 18f, 100f, 100f), "[speed]-sequence-data:" + string.Format("{0:N4}", sequenceData.cart_speed), style);
             GUI.Label(new Rect(30f, 2 * 18f, 100f, 100f), "[speed]-current:" + string.Format("{0:N4}", currentSpeed), style);
        }
        #endregion
    }
}