using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake() => Instance = this;

    [Tooltip("�Ÿ�")]
    public int distance;

    public bool isBoosting;
    public bool isBig;

    [Tooltip("����Ȯ��")]
    public bool isGameStart;

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

    private IEnumerator CSetGame()
    {
        yield return new WaitForSeconds(1f);

    }

    private void Start()
    {
        //StartCoroutine(UpDate());
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
