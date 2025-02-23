using UnityEngine;
using TMPro;


public class DungeonDescriptionDisplayer : MonoBehaviour
{
  [Header("던전 설명 텍스트")]
  [SerializeField] private TextMeshProUGUI descriptionText;

  // 클래스 설명 텍스트 설정
  public void SetDescriptionText(string newText){descriptionText.text = newText;}
}
