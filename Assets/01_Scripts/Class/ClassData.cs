using UnityEngine;

// 클래스 정보를 담는 스크립터블 오브젝트
[CreateAssetMenu(fileName = "NewClass", menuName = "ClassGenerator", order = 1)]
public class ClassData : ScriptableObject
{
  public int id;           // id
  public string className; // 클래스 이름

  // 능력치
  public int strengthWeight;     // 완력 가중치
  public int intelligenceWeight; // 지력 가중치
  public int staminaWeight;      // 견고 가중치
  public int enduranceWeight;    // 지구 가중치
  public int intuitionWeight;    // 직감 가중치

  [TextArea] public string description; // 클래스 설명
}
