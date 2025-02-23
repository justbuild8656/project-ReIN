using UnityEngine;

// 클래스를 선택 할 수 있는 버튼
public class SelectButton : MonoBehaviour
{
  [Header("Class Selector 오브젝트")]
  public ClassSelector classSelector;

  private ClassData currentSelectClass; // 현재 선택된 클래스

  // 현재 선택된 클래스 설정
  public void SetCurrentSelectClass(ClassData newClass){currentSelectClass = newClass;}

  // 버튼을 눌렀을 때 호출
  public void OnButtonClick()
  {
    // 클래스 선택 확정
    if(classSelector != null) classSelector.SetCurrentClass(currentSelectClass);
    else Debug.LogWarning("classSelector가 NULL임");
  }
}
