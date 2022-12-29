using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawner : Singleton<BackGroundSpawner>
{
    [Tooltip("��� �ӵ�")]
    public float backgroundSpd;

    public BackGround standardBackGround;

    [SerializeField]
    private Sprite[] backgroundSprites;

    [Tooltip("���� ��� Index")]
    public int currentBackgroundIndex = 1;

}