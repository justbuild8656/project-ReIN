using CameraSystem;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class TargetingComponent : MonoBehaviour
{
    [Header("EnemyData")]
    public SpawnManager spawnManager;

    [Header("UI")]
    public Image targetingUi;

    //ui�� spawnManager�� ���� �ڵ� ����ȭ,��ü���������� ¥�鼭 ����� �����Դϴ�.
    [Header("TargetingData")]
    public int targetingIndex;

    //�׽�Ʈ ��ǲ�׽�Ʈ ��������
    private void TestInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (spawnManager.enemyObjs.Count - 1 > targetingIndex)
            {
                targetingIndex++;
                CameraManager.Instance.UpdateTargetGroup(targetingIndex + 1);
                TargetingEnemy();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (targetingIndex > 0)
            {
                targetingIndex--;
                CameraManager.Instance.UpdateTargetGroup(targetingIndex + 1);
                TargetingEnemy();
            }
        }
    }

    #region[EventFuction]
    private void Awake()
    {
        InitData();
        
    }
    private void Update()
    {
        TestInput();
        TargetingEnemy();
        UpdateObjectUi();
    }
    #endregion

    #region[SetData]
    //������ �ʱ�ȭ
    private void InitData()
    {
        targetingIndex = 0;
        targetingUi.gameObject.SetActive(true);
        DebugData();
    }
    private void UpdateObjectUi()
    {

        if (targetingUi == null) { return; }
        //���� ī�޶� �þ߰��� ���ٸ� Ui ��Ȱ��ȭ �ݴ�� �ִٸ� Ȱ��ȭ
        if (IsObjectInView(this.gameObject))
        {
            targetingUi.gameObject.SetActive(true);
        }
        else
        {
            targetingUi.gameObject.SetActive(false);
        }
    }
    #endregion

    #region[Ui]

    //Ÿ������ ���� ī�޶� �þ߿� �ִ°� üũ�ϴ� �Լ�
    bool IsObjectInView(GameObject obj)
    {
        // ������Ʈ�� ���� ��ġ�� ī�޶� ����Ʈ ��ǥ�� ��ȯ
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(obj.transform.position);

        // ����Ʈ ��ǥ�� (0, 0) ~ (1, 1) ���̿� ������ ȭ�� �ȿ� ����
        bool isInView = viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
                        viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
                        viewportPoint.z > 0; // z ���� 0���� Ŀ�� ī�޶� ���ʿ� ����

        return isInView;
    }
    //Ui Ÿ���� �Լ�
    private void TargetingEnemy()
    {
        if(spawnManager.enemyObjs.Count != 0)
        {
            //ui�� ������� ������Ʈ�� ��ǥ�� HUD��ǥ�� �����ͼ� Ui�̵�
            targetingUi.transform.position = Camera.main.WorldToScreenPoint(spawnManager.enemyObjs[targetingIndex].transform.GetChild(0).position);
        }
    }
    #endregion

    #region[Debugger]
    private void DebugData()
    {
        //�����
        if (spawnManager == null)
        {
            Debug.LogError("SpawnManager is required in the TargetingComponent.cs");
        }
        if (targetingUi == null)
        {
            Debug.LogError("targetingUi is required in TargetingComponent.cs");
        }
    }
    #endregion
}
