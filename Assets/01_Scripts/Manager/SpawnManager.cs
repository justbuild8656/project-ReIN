using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Range(0,5)]
    public int spawnCount;
    public GameObject enemyObj;
    public Transform spawnPoints;

    private void Awake()
    {
        InitSpawnCount();
    }
    private void InitSpawnCount()
    {
        int initSpawnCount = (spawnPoints.childCount - spawnCount) / 2;
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEnemy(enemyObj, spawnPoints.GetChild(initSpawnCount + i));
        }
    }
    private void SpawnEnemy(GameObject enemyObj,Transform spawnPos)
    {
        Instantiate(enemyObj, spawnPos.position, spawnPos.rotation);
    }
}
