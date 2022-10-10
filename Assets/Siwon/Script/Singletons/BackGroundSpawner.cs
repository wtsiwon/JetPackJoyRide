using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawner : Singleton<BackGroundSpawner>
{

    [Tooltip("���� �ִ� ������ ��´�")]
    public List<BackGround> backgroundList = new List<BackGround>();

    [Tooltip("��� �ӵ�")]
    public float backgroundSpd;

    private void Start()
    {
        SpawnBackGround();
    }

    public void SpawnBackGround()
    {
        ObjPool.Instance.Get(EPoolType.BackGround, transform.position);
    }
}
