using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawner : Singleton<BackGroundSpawner>
{
    //[Tooltip("���� �������� �ִ� ����� �����ϴ� queue")]
    //public Queue<BackGround> backgroundQueue = new Queue<BackGround>();

    [Tooltip("��� �ӵ�")]
    public float backgroundSpd;

    private void Start()
    {
        SpawnBackGround();
    }

    public void SpawnBackGround()
    {
        int rand = Random.Range(0, (int)EPoolType.ShippingBack2 + 1);

        ObjPool.Instance.Get((EPoolType)rand, transform.position);
    }
}
