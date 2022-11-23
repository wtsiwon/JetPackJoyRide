using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleDatas", menuName = "Datas", order = int.MinValue)]
public class ObstacleData : MonoBehaviour
{
    [Tooltip("�帱 ��ֹ� �ִϸ��̼�")]
    public List<RuntimeAnimatorController> drillAnimator = new List<RuntimeAnimatorController>();

    [Tooltip("��� ��ֹ� �ִϸ��̼�")]
    public List<RuntimeAnimatorController> gearAnimator = new List<RuntimeAnimatorController>();
}