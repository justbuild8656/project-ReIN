using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(DungeonDisplayer))]

// 현재 던전 목록을 관리
public class DungeonSelector : MonoBehaviour
{
  [Header("던전 목록")]
  [SerializeField] private List<DungeonData> dungeonList;

  [Header("현재 던전")]
  [SerializeField] private DungeonData currentDungeon;

  // 던전 목록 반환
  public List<DungeonData> GetDungeonList()
  {
    if(dungeonList.Count > 0) return dungeonList;
    else
    {
      Debug.LogWarning("dungeonList 비어있음");
      return new List<DungeonData>();
    }
  }

  // 현재 던전 반환
  public DungeonData GetCurrentDungeon()
  {
    if(currentDungeon != null) return currentDungeon;
    else
    {
      Debug.LogWarning("currentDungeon이 NULL임");
      return null;
    }
  }

  // 현재 던전 설정
  public void SetCurrentDungeon(DungeonData newDungeon)
  {
    if(dungeonList.Contains(newDungeon)) currentDungeon = newDungeon;
    else Debug.LogWarning("newDungeon이 유효하지 않음");
  }

  private void Start(){currentDungeon = null;}
}
