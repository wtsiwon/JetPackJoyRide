using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingElement
{
    public EObstacleType obstacleType;

    public float spinSpd;

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
                Swing();
                break;
            case EObstacleType.Spin:
                Spin();
                break;
        }
    }

    private void Swing()
    {

    }

    private void Spin()
    {
        StartCoroutine(ISpin());
    }

    private IEnumerator ISpin()
    {
        transform.Rotate(new Vector3(0, 0, spinSpd));
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(ISpin());
    }


}
