using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TandomObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToSpawn;//��������Prefab
    public int spawnCount = 10;//���������
    public Vector3 spawnAreaMin;//�X�|�[���G���A�̍ŏ����W
    public Vector3 spawnAreaMax;//�X�|�[���G���A�̍ő���W
    public float spawnInterval = 0.5f;//�o���Ԋu(�b)

    public Vector3 deletePosition = new Vector3(0, 0, -30);
    public float deleteRadius = 13f;

    private List<Vector3> usedPositions= new List<Vector3>();//�g�p�ςݍ��W��ۑ�
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
                //�����_���ȍ��W���v�Z
            } while (usedPositions.Contains(randomPosition));//�d���ōČv�Z

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
