using System;
using UnityEngine;
using System.Collections.Generic;

// 노드 정보 클래스 (에디터에서 사용)
[Serializable]
public class RoomNodeInfo
{
  public string roomID;                                 // 방 ID
  public RoomType roomType;                             // 방 종류
  public List<string> childrenID = new List<string>(); // 자식 노드들의 ID 리스트
}
