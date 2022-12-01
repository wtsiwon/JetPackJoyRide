using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElementSpawner : Singleton<MovingElementSpawner>
{
    [Header("ItemInfos")]
    [Tooltip("Items")]
    public Item[] items;

    [Header("ObstaclePattern prefabs")]
    [Tooltip("ObstacleCoinPattern Prefab")]
    public GameObject[] obstaclePatterns;


    [Header("obstacleAnimationInfos")]
    [Tooltip("��ֹ� Animation Infos")]
    public List<Array<RuntimeAnimatorController>> obstacleAnimation = new List<Array<RuntimeAnimatorController>>();

    public bool isSpawn;

    public ECurrentSpawnType spawnType;

    [Tooltip("���� ��ȯ�� ����")]
    public GameObject beforeSpawnPattern;

    private Vector3 defaultPos = Vector3.zero;

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
                if(beforeSpawnPattern.transform.position.x <= defaultPos.x)
                {
                    if (beforeSpawnPattern == null) yield return null;

                    GetRandomObstaclePattern();
                }
            }
            //���� �Լ�ȣ���
        }
    }

    private void GetRandomObstaclePattern()
    {
        int randPattern = Random.Range(0, obstaclePatterns.Length);
        GameObject obj = Instantiate(obstaclePatterns[randPattern]);
        obj.transform.position = transform.position;

        beforeSpawnPattern = obj;
    }

    private void GetRandomItem()
    {
        int randPattern = Random.Range(0, items.Length);

        Item item = Instantiate(items[randPattern]);
        item.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }
    
}
