using UnityEngine;

// 던전 정보를 담는 스크립터블 오브젝트
[CreateAssetMenu(fileName = "NewDungeon", menuName = "DungeonGenerator", order = 1)]
public class DungeonData : ScriptableObject
{
  public string dungeonName;  // 던전 이름
  public bool canEnter;       // 던전 입장 가능 여부

  [TextArea] public string description; // 던전 설명
}
