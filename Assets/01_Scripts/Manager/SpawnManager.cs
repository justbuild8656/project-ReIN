using CameraSystem;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> enemyObjs = new List<GameObject>();
    public GameObject enemyPrefab;
    public Transform spawnPoints;
    [Range(0, 5)]
    public int spawnCount;

    #region [EventFuction]
    private void Awake()
    {
        DebugData();
    }
    private void Start()
    {
        InitSpawnCount();
    }
    #endregion

    #region[SpawnFuction]
    //�� �����ϴ� �Լ�
    private void InitSpawnCount()
    {
        int initSpawnCount = (spawnPoints.childCount - spawnCount) / 2;
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawnObj = SpawnEnemy(enemyPrefab, spawnPoints.GetChild(initSpawnCount + i));
            Transform targetTransfom = spawnObj.GetComponent<Transform>();
            enemyObjs.Add(spawnObj);
            CameraManager.Instance.UpdateTargetGroup(1);
        }
    }
    //������ ���ӿ�����Ʈ �����ϴ� �Լ�
    private GameObject SpawnEnemy(GameObject enemyObj,Transform spawnPos)
    {
        GameObject spawnObj = Instantiate(enemyObj, spawnPos.position, spawnPos.rotation);
        return spawnObj;
    }
    #endregion

    #region[Debugger]
    private void DebugData()
    {
        //�����
        if (enemyPrefab == null)
        {
            Debug.LogError("enemyPrefab is required in the SpawnManager.cs");
        }
        if (spawnPoints == null)
        {
            Debug.LogError("spawnPoints is required in SpawnManager.cs");
        }
    }
    #endregion
}
