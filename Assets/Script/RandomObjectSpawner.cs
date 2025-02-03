using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TandomObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToSpawn;//生成するPrefab
    public int spawnCount = 10;//生成する個数
    public Vector3 spawnAreaMin;//スポーンエリアの最小座標
    public Vector3 spawnAreaMax;//スポーンエリアの最大座標
    public float spawnInterval = 0.5f;//出現間隔(秒)

    public Vector3 deletePosition = new Vector3(0, 0, -30);
    public float deleteRadius = 13f;

    private List<Vector3> usedPositions= new List<Vector3>();//使用済み座標を保存
    private List<GameObject> spawnedObjects = new List<GameObject>(); 

    public event Action<int> OnObjectSpawned;
    private int objectsSpawned = 0;
    void Start()
    {
        StartCoroutine(SpawnObjects());

    }
    void Update()
    {

    }
    IEnumerator SpawnObjects()
    { 
            Debug.Log($"IN");
        for (int i=0;i<spawnCount;i++)
        {
            Vector3 randomPosition;
            do
            {
                float randomX = UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x);
                float randomY = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);
                float randomZ = UnityEngine.Random.Range(spawnAreaMin.z, spawnAreaMax.z);
                //f++;

                randomPosition=new Vector3(randomX,randomY,randomZ);
                //ランダムな座標を計算
            } while (usedPositions.Contains(randomPosition));//重複で再計算

            usedPositions.Add(randomPosition);

            GameObject clone=Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            spawnedObjects.Add(clone);
            clone.name = "Clone_" + i;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public List<GameObject> GetSpawnedObjects()
    {
        return spawnedObjects;
    }
}
