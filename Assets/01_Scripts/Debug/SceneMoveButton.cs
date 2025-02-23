using System;
using UnityEngine;
using UnityEngine.UI;

/**
 * 싱글톤 오브젝트인 SceneMover 에 접근하기 위한 버튼 스크립트
 */
public class SceneMoveButton : MonoBehaviour
{
    private Button button;
    
    [SerializeField]
    private string sceneName;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneMover.Instance.MoveScene(sceneName);
        });
    }
}
