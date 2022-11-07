using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawner : Singleton<BackGroundSpawner>
{
    [Tooltip("��� �ӵ�")]
    public float backgroundSpd;

    [SerializeField]
    private List<Sprite> backgroundSpriteList = new List<Sprite>();

    [Tooltip("���� ��� Index")]
    public int currentBackgroundIndex = 1;

    private void Start()
    {
        SpawnBackGround();
    }

    public void SpawnBackGround()
    {
        if (currentBackgroundIndex == 3)
        {
            currentBackgroundIndex = 0;
            BackGround back = (BackGround)ObjPool.Instance.Get(EPoolType.BackGround, transform.position);
            back.GetComponent<SpriteRenderer>().sprite = backgroundSpriteList[currentBackgroundIndex];
        }
        else
        {
            BackGround back = (BackGround)ObjPool.Instance.Get(EPoolType.BackGround, transform.position);
            back.GetComponent<SpriteRenderer>().sprite = backgroundSpriteList[currentBackgroundIndex];
        }
        currentBackgroundIndex++;
    }
}
