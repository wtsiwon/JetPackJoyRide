using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElementSpawner : Singleton<MovingElementSpawner>
{
    public ItemData itemData;

    public ObstacleData obstacleData;

    public GameObject[] coinPatterns;

    private void Start()
    {

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
            //���� �Լ�ȣ���
        }

    }

    




}
