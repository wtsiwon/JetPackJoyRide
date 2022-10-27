using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake() => Instance = this;

    [Tooltip("�Ÿ�")]
    [SerializeField]
    private int distance;

    public int Distance
    {
        get
        {
            return distance;
        }
        set
        {
            distance = value;
            distance = (int)(Time.deltaTime * BackGroundSpawner.Instance.backgroundSpd);
            distanceText.text = $"{distance} + m";
        }
    }

    [SerializeField]
    [Tooltip("�Ÿ� Text")]
    private TextMeshProUGUI distanceText;

    public int coin;

    public const float STARTSPD = 8f;

    [Tooltip("����Ȯ��")]
    private bool isGameStart;
    public bool IsGameStart
    {
        get
        {
            return isGameStart;
        }
        set
        {
            isGameStart = value;
            StartCoroutine(CSetGame());
        }
    }

    private void Update()
    {

    }

    private IEnumerator CSetGame()
    {
        MovingElementManager.Instance.BackGroundSpeedSet(STARTSPD);
        BackGroundSpawner.Instance.backgroundSpd = STARTSPD;
        yield return new WaitForSeconds(1f);
        MovingElementManager.Instance.ObstacleSpeedSet(STARTSPD);
        ObstacleSpawner.Instance.canSpawn = true;

    }

    private void Start()
    {
        //StartCoroutine(UpDate());
    }

    private IEnumerator UpDate()
    {
        if (isGameStart == true)
        {
            //�ӵ��� �������� ������ ���� ����
            distance += (int)BackGroundSpawner.Instance.backgroundSpd / 10;
        }
        yield return StartCoroutine(UpDate());
    }

}
