using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElementSpawner : Singleton<MovingElementSpawner>
{
    public Item[] items;

    [Tooltip("ObstacleCoinPattern Prefab")]
    public GameObject[] obstaclePatterns;

    public ObstacleData obstacleData;

    public bool isSpawn;

    public ECurrentSpawnType spawnType;

    [Tooltip("���� ��ȯ�� ����")]
    private GameObject beforeSpawnPattern;


    private void Start()
    {
        StartCoroutine(nameof(CUpdate));
        
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <returns></returns>
    private IEnumerator CUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            
            if(isSpawn == true)
            {

            }
            //���� �Լ�ȣ���
        }
    }

    private void GetRandomObstaclePattern()
    {
        int randPattern = Random.Range(0, obstaclePatterns.Length);
        GameObject obj = Instantiate(obstaclePatterns[randPattern]);
        obj.transform.position = transform.position;
    }

    private void GetRandomItem()
    {
        int randPattern = Random.Range(0, items.Length);

        Item item = Instantiate(items[randPattern]);
        item.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }
    
}
