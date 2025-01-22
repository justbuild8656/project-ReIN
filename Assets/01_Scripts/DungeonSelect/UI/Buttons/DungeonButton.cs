using UnityEngine;
using TMPro;

// 던전을 고를 수 있는 버튼
public class DungeonButton : MonoBehaviour
{
  [Header("던전")]
  [SerializeField] private DungeonData dungeonData;

  private DungeonSelectButton selectButton; // 던전 선택 확정 버튼

  // 버튼을 눌렀을 때 호출
  public void OnButtonClick()
  {
    if(dungeonData == null)
    {
      Debug.LogWarning("dungeonData NULL임");
      return;
    }

    Transform dungeonSelect = FindDungeonSelect();
    
    if(dungeonSelect != null)
    {
      // 1. 던전 설명 표시
      DungeonDescriptionDisplayer displayer = dungeonSelect.GetComponent<DungeonDescriptionDisplayer>();
      string newDescription = dungeonData.description;

      if(displayer != null) displayer.SetDescriptionText(newDescription);
    }

    if(selectButton != null)
    {
      // 2. 임시 선택 클래스 전달
      selectButton.SetCurrentSelectClass(dungeonData);
    }
  }

  // Dungeon Select 오브젝트를 찾는 메서드
  public Transform FindDungeonSelect()
  {
    // 부모 오브젝트를 순회하며 Dungeon Select 오브젝트를 찾음
    Transform parent = transform.parent;

    while(parent != null)
    {
      if(parent.name == "Dungeon Select") return parent;
      parent = parent.parent;
    }

    Debug.LogWarning("부모 오브젝트 DungeonSelect를 찾을 수 없음");
    return null;
  }

  // UI가 생성될 때 DungeonData 지정하는 매서드
  public void SetDungeonData(DungeonData newDungeon){dungeonData = newDungeon;}

  private void Start()
  {
    if(dungeonData == null) Debug.LogWarning("dungeonData NULL임");

    // 버튼 텍스트 설정
    TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

    if(text != null)
    {
      string newText = dungeonData.dungeonName;

      if(dungeonData.canEnter) newText += "\n Can Enter";
      else newText += "\n Can't Enter";

      text.text = newText;
    }
    else Debug.LogWarning("자식 오브젝트에 TextMeshProUGUI가 없음");

    // selectButton 캐싱
    selectButton = GameObject.Find("Dungeon Select Btn").GetComponent<DungeonSelectButton>();

    if(selectButton == null) Debug.LogWarning("DungeonSelectButton 컴포넌트를 찾을 수 없음");
  }
}
