using UnityEngine;
using UnityEngine.UI;

public class DungeonButtonSelector : MonoBehaviour
{
  private GameObject selectedButton; // 현재 선택 된 버튼

  // 버튼 선택 이벤트 처리 매서드
  // 그래픽 소스가 나오면 버튼의 색상이 아닌 테두리의 색상을 바꾸는 것으로 수정
  public void OnButtonClick(GameObject clickedButton)
  {
    if (selectedButton != null && selectedButton != clickedButton)
    {
      // 선택 해제 색상을 하얀색으로 바꿈
      Image previousImage = selectedButton.GetComponent<Image>();
      previousImage.color = Color.white;
    }

    // 선택 시 색상을 초록색으로 바꿈
    Image clickedImage = clickedButton.GetComponent<Image>();
    clickedImage.color = Color.green;

    selectedButton = clickedButton;
  }
}
