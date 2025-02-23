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
    [System.Serializable]

    public class CameraManager : MonoBehaviour
    {
        //인스턴스화
        private static CameraManager instance;
        public static CameraManager Instance { get => instance; }

        //카메라 모드
        [Header("Camera_Mode")]
        public CameraMode cameraMode = CameraMode.Default;

        //기본캠 
        [Header("Cinemachine_Cameras")]
        [SerializeField] CinemachineCamera camDefault;

        [Header("TargetGroup")]
        public CinemachineTargetGroup targetGroup;

        //카메라 흔들림 효과 컴퍼넌트
        private CinemachineImpulseSource source;

        #region[EventFunction]
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
        #endregion

        #region[Set Data]
        private void Initialize()
        {
            instance = this;

            //컴퍼넌트 가져오기
            source = Camera.main.gameObject.GetComponent<CinemachineImpulseSource>();
            DebugData();

            //초기화 세팅
            cameraMode = CameraMode.Default;
            ChangeCameraMode(cameraMode);
        }
        //이후 카메라를 여러개 추가할때 카메라 모드 이용예정
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
        public void SetTargetGroup(Transform enemyTransform)
        {
            if (enemyTransform != null)
            {
                //타겟그룹에 트랜스폼 데이터를 추가하기
                targetGroup.AddMember(enemyTransform, 0.2f, 0.0f);
                //초기화 세팅하기
                targetGroup.Targets[1].Weight = 0.4f;
            }
        }
        public void UpdateTargetGroup(int index)
        {
            //전체 초기화하기
            for (int i = 0; i < targetGroup.Targets.Count; i++)
            {
                targetGroup.Targets[i].Weight = 0.2f;
            }
            //플레이어는 무조건 1로 세팅하기
            targetGroup.Targets[0].Weight = 1f;
            //선택한 타겟팅 인덱스의 가중치 증가하기
            targetGroup.Targets[index].Weight = 0.4f;
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
        private void DebugData()
        {
            //디버깅
            if (source == null)
            {
                Debug.LogError("CinemachineImpulseSource is required in the main camera and CameraManager.cs");
            }
            if (camDefault == null)
            {
                Debug.LogError("camDefault is required in CameraManager.cs");
            }
            if (targetGroup == null)
            {
                Debug.LogError("targetGroup is required in CameraManager.cs");
            }
        }
        #endregion
    }
}