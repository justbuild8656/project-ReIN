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
        TargetingEnemy();
    }
    private void Update()
    {
        TestInput();
    }
    private void TestInput()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(spawnManager.enemyObjs.Count-1 > targetingIndex)
            {
                targetingIndex++;
                TargetingEnemy();
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (targetingIndex > 0)
            {
                targetingIndex--;
                TargetingEnemy();
            }
        }
    }
    private void TargetingEnemy()
    {
        targetingUi.transform.position = Camera.main.WorldToScreenPoint(spawnManager.enemyObjs[targetingIndex].transform.GetChild(0).position);
    }
}
