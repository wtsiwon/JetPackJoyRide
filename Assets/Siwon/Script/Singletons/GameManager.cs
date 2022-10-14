using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("�Ÿ�")]
    public int distance;

    public bool isBoosting;
    public bool isBig;

    [SerializeField]
    private bool gameStart;
    public bool GameStart
    {
        get
        {
            return gameStart;
        }
        set
        {
            GameStart = value;
            if (GameStart == true)
            {

            }
        }
    }

    private void Start()
    {
        StartCoroutine(UpDate());
    }

    private IEnumerator UpDate()
    {
        if(GameStart == true)
        {
            //�ӵ��� �������� ������ ���� ����
            distance += (int)BackGroundSpawner.Instance.backgroundSpd / 10;
        }
        yield return StartCoroutine(UpDate());
    }

}
