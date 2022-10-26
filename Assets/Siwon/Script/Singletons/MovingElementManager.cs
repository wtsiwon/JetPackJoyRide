using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElementManager : Singleton<MovingElementManager>
{
    [Tooltip("���� �����ִ� MovingElements")]
    public List<MovingElement> movingElementList = new List<MovingElement>();
    //���⼭ ��ֹ� ��������, �����ۻ���, ����� �ӵ� ���� ������ ����


    public void BackGroundSpeedSet(float spd)
    {
        foreach (MovingElement background in movingElementList)
        {
            if (background is BackGround)
            {
                background.SetMovingSpd(spd);
            }
        }
    }
    public void ObstacleSpeedSet(float spd)
    {
        foreach (MovingElement obstacle in movingElementList)
        {
            if (obstacle is Obstacle)
            {
                obstacle.SetMovingSpd(spd);
            }
        }
    }
    public void ItemSpeedSet(float spd)
    {
        foreach (MovingElement item in movingElementList)
        {
            if(item is Item)
            {
                item.SetMovingSpd(spd);
            }
        }
    }

    public void MovingElementSpeedSet(float spd)
    {
        foreach(MovingElement movingElement in movingElementList)
        {
            movingElement.SetMovingSpd(spd);
        }
    }
}
