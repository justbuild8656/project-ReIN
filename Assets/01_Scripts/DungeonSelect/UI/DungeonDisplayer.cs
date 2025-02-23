using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(DungeonSelector))]
[RequireComponent(typeof(DungeonButtonSelector))]

// 던전 선택 버튼을 동적으로 관리
public class DungeonDisplayer : MonoBehaviour
{
  [Header("UI")]
  public GameObject buttonPrefab; // 던전 프리팹
  public Transform contentParent; // 스크롤 뷰의 content

  private DungeonSelector dungeonSelector;   // 던전 샐렉터
  private DungeonButtonSelector dungeonButtonSelector; // 버튼 셀렉터

  private void Start()
  {
    dungeonSelector = GetComponent<DungeonSelector>();
    dungeonButtonSelector = GetComponent<DungeonButtonSelector>();

    // 버튼 생성
    GenerateClassButtons();
  }

  // 클래스 버튼 동적 생성
  private void GenerateClassButtons()
  {
    // 1. dungeonSelector에서 던전을 리스트를 받아옴
    List<DungeonData> dungeonList = dungeonSelector.GetDungeonList();

    if(dungeonList == null || dungeonList.Count ==0)
    {
      Debug.LogWarning("dungeonList가 비어있음");
      return;
    }

    // 2. 기존 자식 오브젝트를 삭제(중복 방지)
    foreach(Transform child in contentParent) Destroy(child.gameObject);

    // 3. dungeonList를 순회하며 UI를 동적 생성
    foreach(DungeonData dungeonData in dungeonList)
    {
      GameObject newButton = Instantiate(buttonPrefab, contentParent);

      // 3-1. 새로 생성된 버튼의 DungeonData를  지정
      DungeonButton newDungeonButton = newButton.GetComponent<DungeonButton>();

      if(newDungeonButton != null) newDungeonButton.SetDungeonData(dungeonData);
      else Debug.LogWarning("DungeonButton 컴포넌트를 찾을 수 없음");

      // 3.2 버튼 클릭 이벤트 추가
      Button newButtonComponent = newButton.GetComponent<Button>();
      newButtonComponent.onClick.AddListener(() => dungeonButtonSelector.OnButtonClick(newButton));
    }
  }
}
