using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��ֹ��� ��ȯ�� ��ġ��")]
    private List<Transform> poses = new List<Transform>();

    private IEnumerator ISpawnPattern1()
    {
        yield return new WaitForSeconds(1f);
        int rand = Random.Range(0, poses.Count);
        //ObjPool.Instance.GetObstacle()
        yield return null;
    }


}
