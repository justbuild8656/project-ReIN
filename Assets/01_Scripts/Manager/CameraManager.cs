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
        //�ν��Ͻ�ȭ
        private static CameraManager instance;
        public static CameraManager Instance { get => instance; }

        //ī�޶� ���
        [Header("Camera_Mode")]
        public CameraMode cameraMode = CameraMode.Default;

        //�⺻ķ 
        [Header("Cinemachine_Cameras")]
        [SerializeField] CinemachineCamera camDefault;

        [Header("TargetGroup")]
        public CinemachineTargetGroup targetGroup;

        //ī�޶� ��鸲 ȿ�� ���۳�Ʈ
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

        // Test:���Ŀ� �ڵ� ������ ����
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

            //���۳�Ʈ ��������
            source = Camera.main.gameObject.GetComponent<CinemachineImpulseSource>();
            DebugData();

            //�ʱ�ȭ ����
            cameraMode = CameraMode.Default;
            ChangeCameraMode(cameraMode);
        }
        //���� ī�޶� ������ �߰��Ҷ� ī�޶� ��� �̿뿹��
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
                //Ÿ�ٱ׷쿡 Ʈ������ �����͸� �߰��ϱ�
                targetGroup.AddMember(enemyTransform, 0.2f, 0.0f);
                //�ʱ�ȭ �����ϱ�
                targetGroup.Targets[1].Weight = 0.4f;
            }
        }
        public void UpdateTargetGroup(int index)
        {
            //��ü �ʱ�ȭ�ϱ�
            for (int i = 0; i < targetGroup.Targets.Count; i++)
            {
                targetGroup.Targets[i].Weight = 0.2f;
            }
            //�÷��̾�� ������ 1�� �����ϱ�
            targetGroup.Targets[0].Weight = 1f;
            //������ Ÿ���� �ε����� ����ġ �����ϱ�
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
            //�����
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