using UnityEngine;
using TMPro;

// 클래스 정보를 표시
public class DescriptionDisplayer : MonoBehaviour
{
  [Header("클래스 설명 텍스트")]
  [SerializeField] private TextMeshProUGUI descriptionText;

  // 클래스 설명 텍스트 설정
  public void SetDescriptionText(string newText){descriptionText.text = newText;}
}
