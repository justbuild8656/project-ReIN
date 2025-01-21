using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(ClassDisplayer))]

// 현재 클래스 목록을 관리
public class ClassSelector : MonoBehaviour
{
  [Header("클래스 목록")]
  [SerializeField] private List<ClassData> classList;

  [Header("현재 클래스")]
  [SerializeField] private ClassData currentClass;

  // 클래스 목록 반환
  public List<ClassData> GetClassList()
  {
    if(classList.Count > 0) return classList;
    else
    {
      Debug.LogWarning("classList가 비어있음");
      return new List<ClassData>();
    }
  }

  // 현재 클래스 반환
  public ClassData GetCurrentClass()
  {
    if(currentClass != null) return currentClass;
    else
    {
      Debug.LogWarning("currentClass가 NULL임");
      return null;
    }
  }

  // 현재 클래스 설정
  public void SetCurrentClass(ClassData newClass)
  {
    if(classList.Contains(newClass)) currentClass = newClass;
    else Debug.LogWarning("newClass가 유효하지 않음");
  }

  private void Start(){currentClass = null;}
}
