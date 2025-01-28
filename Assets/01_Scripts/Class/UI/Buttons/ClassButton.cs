using TMPro;
using UnityEngine;

// 클래스를 고를 수 있는 버튼
public class ClassButton : MonoBehaviour
{
  [Header("클래스")]
  [SerializeField] private ClassData classData;

  private SelectButton selectButton; // 클래스 선택 확정 버튼

  // 버튼을 눌렀을 때 호출
  public void OnButtonClick()
  {
    if(classData == null)
    {
      Debug.LogWarning("classData가 NULL임");
      return;
    }

    Transform classSelect = FindClassSelect();
    
    if(classSelect != null)
    {
      // 1. 클래스 설명 표시
      DescriptionDisplayer displayer = classSelect.GetComponent<DescriptionDisplayer>();
      string newDescription = classData.description;

      if(displayer != null) displayer.SetDescriptionText(newDescription);
    }

    if(selectButton != null)
    {
      // 2. 임시 선택 클래스 전달
      selectButton.SetCurrentSelectClass(classData);
    }
  }

  // Class Select 오브젝트를 찾는 메서드
  public Transform FindClassSelect()
  {
    // 부모 오브젝트를 순회하며 Class Select 오브젝트를 찾음
    Transform parent = transform.parent;

    while(parent != null)
    {
      if(parent.name == "Class Select") return parent;
      parent = parent.parent;
    }

    Debug.LogWarning("부모 오브젝트 ClassSelect를 찾을 수 없음");
    return null;
  }

  // UI가 생성될 때 classData를 지정하는 매서드
  public void SetClassData(ClassData newCLass){classData = newCLass;}

  private void Start()
  {
    if(classData == null) Debug.LogWarning("classData가 NULL임");

    // 버튼 텍스트 설정
    TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

    if(text != null) text.text = classData.className;
    else Debug.LogWarning("자식 오브젝트에 TextMeshProUGUI가 없음");

    // selectButton 캐싱
    selectButton = GameObject.Find("Class Select Btn").GetComponent<SelectButton>();

    if(selectButton == null) Debug.LogWarning("SelectButton 컴포넌트를 찾을 수 없음");
  }
}
