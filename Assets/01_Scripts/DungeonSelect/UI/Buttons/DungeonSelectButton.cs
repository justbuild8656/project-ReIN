using UnityEngine;

// 던전을 선택 할 수 있는 버튼
public class DungeonSelectButton : MonoBehaviour
{
  [Header("Dungeon Selector 오브젝트")]
  public DungeonSelector dungeonSelector;

  private DungeonData currentSelectDungeon; // 현재 선택된 클래스

  // 현재 선택된 던전 설정
  public void SetCurrentSelectClass(DungeonData newDungeon){currentSelectDungeon = newDungeon;}

  // 버튼을 눌렀을 때 호출
  public void OnButtonClick()
  {
    // 던전 선택 확정
    if(dungeonSelector != null) dungeonSelector.SetCurrentDungeon(currentSelectDungeon);
    else Debug.LogWarning("classSelector가 NULL임");
  }
}
