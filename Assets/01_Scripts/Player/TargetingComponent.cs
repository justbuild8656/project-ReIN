using CameraSystem;
using UnityEngine;
using UnityEngine.UI;

public class TargetingComponent : MonoBehaviour
{
    public Image targetingUi;
    public int targetingIndex;
    public SpawnManager spawnManager;
    private void Awake()
    {
        targetingIndex = 0;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        TestInput();
        TargetingEnemy();
    }
    private void TestInput()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(spawnManager.enemyObjs.Count-1 > targetingIndex)
            {
                targetingIndex++;
                CameraManager.Instance.UpdateTargetGroup(targetingIndex+1);
                TargetingEnemy();
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (targetingIndex > 0)
            {
                targetingIndex--;
                CameraManager.Instance.UpdateTargetGroup(targetingIndex+1);
                TargetingEnemy();
            }
        }
    }
    private void TargetingEnemy()
    {
        if(spawnManager.enemyObjs.Count != 0)
        {
            targetingUi.transform.position = Camera.main.WorldToScreenPoint(spawnManager.enemyObjs[targetingIndex].transform.GetChild(0).position);
        }
    }
}
