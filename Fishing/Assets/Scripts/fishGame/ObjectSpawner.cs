using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("生成设置")]
    public GameObject objectToSpawn;
    public float spawnInterval = 2f;//生成间隔
    public Vector2 spawnAreaSize = new Vector2(10f, 10f);
    private int currentCount=0;
    public int maxCount=3;
    [Header("调试")]
    public bool showGizmos = true;

    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void InitFish()
    {
        StartCoroutine(SpawnObjects());
        Debug.Log("11");

    }
    IEnumerator SpawnObjects()
    {
        while (true&&currentCount<=maxCount)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
        }
        currentCount = 0;
    }

    void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            Vector3 randomPosition = GetRandomPositionInArea();
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            currentCount++;
        }
    }

    Vector3 GetRandomPositionInArea()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );
        return transform.position + (Vector3)randomPosition;
    }
    //绘制面积大小
    void OnDrawGizmosSelected()
    {
        if (!showGizmos) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0));
    }
}