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

    //ui랑 spawnManager는 이후 코드 최적화,객체지향적으로 짜면서 사라질 예정입니다.
    [Header("TargetingData")]
    public int targetingIndex;

    //테스트 인풋테스트 삭제예정
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
    //데이터 초기화
    private void InitData()
    {
        targetingIndex = 0;
        targetingUi.gameObject.SetActive(true);
        DebugData();
    }
    private void UpdateObjectUi()
    {

        if (targetingUi == null) { return; }
        //적이 카메라 시야각에 없다면 Ui 비활성화 반대로 있다면 활성화
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

    //타겟팅할 적이 카메라 시야에 있는걸 체크하는 함수
    bool IsObjectInView(GameObject obj)
    {
        // 오브젝트의 월드 위치를 카메라 뷰포트 좌표로 변환
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(obj.transform.position);

        // 뷰포트 좌표가 (0, 0) ~ (1, 1) 사이에 있으면 화면 안에 있음
        bool isInView = viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
                        viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
                        viewportPoint.z > 0; // z 값이 0보다 커야 카메라 앞쪽에 있음

        return isInView;
    }
    //Ui 타겟팅 함수
    private void TargetingEnemy()
    {
        if(spawnManager.enemyObjs.Count != 0)
        {
            //ui를 월드상의 오브젝트의 좌표를 HUD좌표로 가져와서 Ui이동
            targetingUi.transform.position = Camera.main.WorldToScreenPoint(spawnManager.enemyObjs[targetingIndex].transform.GetChild(0).position);
        }
    }
    #endregion

    #region[Debugger]
    private void DebugData()
    {
        //디버깅
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
