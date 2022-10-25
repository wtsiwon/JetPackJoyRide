using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MovingElement
{
    public EObstacleType obstacleType;

    [Range(0f, 5f)]
    [Tooltip("���ư��� �ӵ�")]
    public float spinSpd;

    [Tooltip("�ִ� ����")]
    public float maxAngle;

    [Tooltip("�ּ� ����")]
    public float minAngle;

    [Tooltip("SwingSpd")]
    private const float swingSpd = 100;

    private Vector3 spawnPoint;

    private const float DISTANCE = 50f;

    //���߿� �� �� �����ؼ� �غ���
    protected override void OnEnable()
    {
        spawnPoint = Player.Instance.transform.position;

        base.OnEnable();
        TypeofDefine();
    }

    /// <summary>
    /// enumŸ���� ���� ����
    /// obstacleType�� ���� ��ֹ� 
    /// </summary>
    private void TypeofDefine()
    {
        switch (obstacleType)
        {
            case EObstacleType.Basic:
                //����
                break;
            case EObstacleType.Swing:
                Swing();
                break;
            case EObstacleType.Spin:
                Spin();
                break;
        }
    }

    private void Update()
    {
        if (spawnPoint.x - transform.position.x > DISTANCE)
        {
            Return();
        }

        if (obstacleType == EObstacleType.Swing)
        {
            //Swing();
        }
    }

    private void Swing()
    {
        StartCoroutine(CSwing());
    }

    private IEnumerator CSwing()
    {
        yield return new WaitForSeconds(1f);
        if (transform.rotation.z >= 50)
        {
            transform.DORotate(new Vector3(0, 0, -50), 1f);
        }
        else if (transform.rotation.z <= -50)
        {
            transform.DORotate(new Vector3(0, 0, 50), 1f);
        }
        yield return StartCoroutine(CSwing());
    }

    private void Spin()
    {
        StartCoroutine(CSpin());
    }

    private IEnumerator CSpin()
    {
        transform.Rotate(new Vector3(0, 0, spinSpd));
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(CSpin());
    }


}
