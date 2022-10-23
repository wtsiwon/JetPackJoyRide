using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //���߿� �� �� �����ؼ� �غ���
    protected override void OnEnable()
    {
        //base.OnEnable();
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
                //Swing();
                break;
            case EObstacleType.Spin:
                Spin();
                break;
        }
    }

    private void Update()
    {
        if(obstacleType == EObstacleType.Swing)
        {
            Swing();
        }
    }
    private void Swing()
    {
        //�Դ� ���� �ϴ� �ڵ�
        if (Mathf.Abs(transform.rotation.z) >= 50)
        {
            transform.Rotate(new Vector3(0, 0, swingSpd * -1));
        }
    }

    private IEnumerator CSwing()
    {
        yield return null;
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
