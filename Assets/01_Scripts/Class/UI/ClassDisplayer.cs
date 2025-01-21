using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

//[RequireComponent(typeof(ClassSelector))]
//[RequireComponent(typeof(ButtonSelector))]

// 클래스 선택 버튼을 동적으로 관리
public class ClassDisplayer : MonoBehaviour
{
  [Header("UI")]
  public GameObject buttonPrefab; // 버튼 프리팹
  public Transform contentParent; // 스크롤 뷰의 content

  private ClassSelector classSelector;   // 클래스 샐렉터
  private ButtonSelector buttonSelector; // 버튼 셀렉터

  private void Start()
  {
    classSelector = GetComponent<ClassSelector>();
    buttonSelector = GetComponent<ButtonSelector>();

    // 버튼 생성
    GenerateClassButtons();
  }

  // 클래스 버튼 동적 생성
  private void GenerateClassButtons()
  {
    // 1. classSelector에서 클래스 리스트를 받아옴
    List<ClassData> classList = classSelector.GetClassList();

    if(classList == null || classList.Count ==0)
    {
      Debug.LogWarning("classList가 비어있음");
      return;
    }

    // 2. 기존 자식 오브젝트를 삭제(중복 방지)
    foreach(Transform child in contentParent) Destroy(child.gameObject);

    // 3. classList를 순회하며 UI를 동적 생성
    foreach(ClassData classData in classList)
    {
      GameObject newButton = Instantiate(buttonPrefab, contentParent);

      // 3-1. 새로 생성된 버튼의 ClassData를  지정
      ClassButton newClassButton = newButton.GetComponent<ClassButton>();

      if(newClassButton != null) newClassButton.SetClassData(classData);
      else Debug.LogWarning("ClassButton 컴포넌트를 찾을 수 없음");

      // 3.2 버튼 클릭 이벤트 추가
      Button newButtonComponent = newButton.GetComponent<Button>();
      newButtonComponent.onClick.AddListener(() => buttonSelector.OnButtonClick(newButton));
    }
  }
}
