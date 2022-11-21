using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleDatas", menuName = "Datas", order = int.MinValue)]
public class ObstacleData : MonoBehaviour
{
    [Tooltip("�帱 ��ֹ�Datas")]
    public List<Obstacle> drillObstacleDatas = new List<Obstacle>();

    [Tooltip("��� ��ֹ�Datas")]
    public List<Obstacle> gearObstacleDatas = new List<Obstacle>();

    [Tooltip("�ָ� ��ֹ�Datas")]
    public List<Obstacle> fistObstacleDatas = new List<Obstacle>();
    
}
