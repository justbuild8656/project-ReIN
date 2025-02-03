using UnityEngine;
using System.Collections.Generic;

// 맵 생성기 클래스
public class MapGenerator : MonoBehaviour
{
  public RoomTree mapTree; // 맵 트리

  // 트리 생성 매서드
  public void CreateTree(RoomNodeInfo[] mapData, int maxDepth)
  {
    if(mapData == null || mapData.Length == 0){
      Debug.Log("맵 데이터가 없음");
      return;
    }

    RoomTree tree = new RoomTree(maxDepth);
    Dictionary<string, RoomNode> nodeDictionary = new Dictionary<string, RoomNode>();

    // 1. 모든 노드 먼저 생성
    foreach(var nodeInfo in mapData){
      RoomNode newNode = new RoomNode(nodeInfo.roomID, 1, nodeInfo.roomType);
      nodeDictionary[nodeInfo.roomID] = newNode;
    }

    // 2. 부모 노드가 자식 노드를 참조
    foreach(var nodeInfo  in mapData){
      // 루트 노드 설정
      if(nodeInfo.roomType == RoomType.Start){
        if(!tree.SetRoot(nodeDictionary[nodeInfo.roomID])){Debug.LogError($"루트 노드 설정 실패: {nodeInfo.roomID}"); return;}
      }

      // 자식 노드 설정
      if(nodeDictionary.TryGetValue(nodeInfo.roomID, out RoomNode parentNode)){
        if(nodeInfo.childrenID.Count > 0){
          foreach(var childID in nodeInfo.childrenID){
            if(nodeDictionary.TryGetValue(childID, out RoomNode childNode)){childNode.depth = parentNode.depth + 1; parentNode.AddChild(childNode);}
            else{Debug.LogError($"자식 노드 {childID}를 찾을 수 없음"); return;}
          }
        }
        else parentNode.roomType = RoomType.End;
      }
      else{Debug.LogError($"부모 노드 {nodeInfo.roomID}를 찾을 수 없음"); return;}
    }

    mapTree = tree;
  }

  // 맵 트리 반환 매서드
  public RoomTree GetMapTree(){
    return mapTree;
  }
}