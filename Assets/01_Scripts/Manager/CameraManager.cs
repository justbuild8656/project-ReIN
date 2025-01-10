using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.Cinemachine;
using UnityEngine.Splines;
using NUnit.Framework.Internal;
namespace LocomotionSystem
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
        [Header("Transition_State")]
        public TransitionState transition_state = TransitionState.None;

        //camera_mode
        [Header("Camera_Mode")]
        public CameraMode camera_mode = CameraMode.Default;

        //default,cutscene,target
        [Header("Cinemachine_Cameras")]
        [SerializeField] CinemachineCamera cam_default;
        [SerializeField] CinemachineCamera cam_sequence;
        [SerializeField] CinemachineCamera cam_targeting;

        //cameraShake_Component
        private CinemachineImpulseSource source;

        [Header("Cinemachine_Sequence")]
        public SplineContainer splineContainer;
        public SO_Cam_SequenceData sequenceData;
        private CinemachineSplineDolly cart;

        //camera_parameter
        [Header("Camera_Paramter")]
        public float current_speed;
        private void Awake()
        {
            Initialize();
        }
        private void Update()
        {
            TestInput();
        }
        private void TestInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeCameraMode(CameraMode.Default);
                var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
                if (autodolly != null)
                {
                    current_speed = 0.0f;
                    autodolly.Speed = current_speed;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(current_speed!=0.0f||transition_state!=TransitionState.Transition)
                {
                    ChangeCameraMode(CameraMode.Sequence);
                    SetSequenceData(sequenceData);
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
            cart = cam_sequence.GetComponent<CinemachineSplineDolly>();

            //test
            SetSequenceData(sequenceData);

            //init_setting
            camera_mode = CameraMode.Default;
            cart.CameraPosition = 0.0f;
            var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
            if (autodolly != null)
            {
                current_speed = 0.0f;
                autodolly.Speed = current_speed;
            }
            ChangeCameraMode(camera_mode);

            
        }
        public void ChangeCameraMode(CameraMode p_camera_mode)
        {
            camera_mode = p_camera_mode;
            switch (camera_mode)
            {
                case CameraMode.Default:
                    cam_default.Priority = 10;
                    cam_sequence.Priority = 0;
                    cam_targeting.Priority = 0;
                    break;
                case CameraMode.Sequence:
                    cam_default.Priority = 0;
                    cam_sequence.Priority = 10;
                    cam_targeting.Priority = 0;
                    break;
                case CameraMode.Targeting:
                    cam_default.Priority = 0;
                    cam_sequence.Priority = 0;
                    cam_targeting.Priority = 10;
                    break;
            }

        }

        public IEnumerator UpdateTransitionState()
        {
            transition_state = TransitionState.Transition;
            yield return new WaitForSeconds(1.6f);
            transition_state = TransitionState.None;
            cart.CameraPosition = 0.0f;//reset CameraSpline
            var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
            if (autodolly != null)
            {
                current_speed = 0.0f;
                autodolly.Speed = current_speed;
            }
        }

        #region[Default]

        #endregion

        #region [Sequence]
        
        public void SetSequenceData(SO_Cam_SequenceData sequence_data)
        {
            if(sequenceData!=null)
            {
                cart.CameraPosition = 0.0f;//reset CameraSpline
                var autodolly = cart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
                if (autodolly != null)
                {
                    current_speed = sequence_data.cart_speed;
                    autodolly.Speed = current_speed;
                }
                splineContainer.Spline = sequenceData.waypoints;
            }        
        }
        #endregion

        #region[Targeting]
        public void SetCameraTargetPosition(Vector3 target_position,Quaternion target_rotation)
        {
            cam_targeting.transform.position = target_position;
            cam_targeting.transform.rotation = target_rotation;
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
            GUI.Label(new Rect(0f,0f,100f,100f),"[camera_mode]:"+ camera_mode.ToString(),style);
            GUI.Label(new Rect(30f, 1 * 18f, 100f, 100f), "[speed]-sequence-data:" + string.Format("{0:N4}", sequenceData.cart_speed), style);
             GUI.Label(new Rect(30f, 2 * 18f, 100f, 100f), "[speed]-current:" + string.Format("{0:N4}", current_speed), style);
        }
        #endregion
    }
}