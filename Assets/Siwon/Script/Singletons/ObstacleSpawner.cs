using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

using System;

public class ObstacleSpawner : Singleton<ObstacleSpawner>
{
    [SerializeField]
    [Tooltip("��ֹ��� ��ȯ�� ��ġ��")]
    private List<Transform> spawnPoses = new List<Transform>();

    [Tooltip("���� ���� ��� Dictionary")]
    private Dictionary<EDir, Quaternion> rotatesDic = new Dictionary<EDir, Quaternion>();

    [Tooltip("��ֹ� Sprite�� enumŸ�Կ� ���� �з��� dictionary")]
    private Dictionary<EObstacleType, Sprite> obstacleSpriteDic = new Dictionary<EObstacleType, Sprite>();

    [Tooltip("��ֹ� Sprite��List")]
    [Space(15f)]
    public List<Sprite> obstacleSpriteList = new List<Sprite>();

    [Tooltip("��ֹ� ��ȯ ����")]
    public const float OBSTACLESPAWNINTERVAL = 7f;

    public bool canSpawn;

    private void Start()
    {
        AddRotates();
        //AddObstacleSprite();
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            if (canSpawn)
            {
                int rand = Random.Range(1, 16);
                SpawnPattern(rand);
            }
            yield return new WaitForSeconds(7f);
        }
    }

    /// <summary>
    /// ��ֹ� SpriteDictionary�� �߰�
    /// </summary>
    private void AddObstacleSprite()
    {
        for (int i = 0; i < (int)EObstacleType.End; i++)
        {
            obstacleSpriteDic.Add((EObstacleType)i, obstacleSpriteList[i]);
        }
    }

    private void AddRotates()
    {
        rotatesDic.Add(EDir.Up, new Quaternion(0, 0, (float)EDir.Up, 0));
        rotatesDic.Add(EDir.Down, new Quaternion(0, 0, (float)EDir.Down, 0));
        rotatesDic.Add(EDir.Left, new Quaternion(0, 0, (float)EDir.Left, 0));
        rotatesDic.Add(EDir.Right, new Quaternion(0, 0, (float)EDir.Right, 0));
    }

    /// <summary>
    /// ���ϼ�ȯ!
    /// </summary>
    /// <param name="index"></param>
    public void SpawnPattern(int index)
    {
        StartCoroutine($"CSpawnPattern{index}");
    }

    #region ���� �Լ���
    private IEnumerator CSpawnPattern1()
    {
        yield return new WaitForSeconds(1f);
        Obstacle obstacle1 = GetBasicObstacle(spawnPoses[1]);
        obstacle1.transform.rotation = rotatesDic[EDir.Up];

        yield return new WaitForSeconds(1f);
        Obstacle obstacle2 = GetSwingObstacle(spawnPoses[4]);
    }

    private IEnumerator CSpawnPattern2()
    {
        yield return new WaitForSeconds(0.5f);
        Obstacle obstacle1 = GetSpinObstacle(spawnPoses[2]);

        yield return new WaitForSeconds(0.5f);
        Obstacle obstacle2 = GetBasicObstacle(spawnPoses[2]);

        yield return new WaitForSeconds(1f);
        Obstacle obstacle3 = GetBasicObstacle(spawnPoses[4]);
        obstacle3.transform.rotation = rotatesDic[EDir.Down];
    }

    private IEnumerator CSpawnPattern3()
    {
        yield return new WaitForSeconds(2.5f);
        Obstacle obstacle1 = GetSwingObstacle(spawnPoses[4]);

        yield return new WaitForSeconds(1.5f);
        Obstacle obstacle2 = GetSpinObstacle(spawnPoses[1]);

        yield return new WaitForSeconds(2f);
        Obstacle obstacle3 = GetSwingObstacle(spawnPoses[1]);
    }

    private IEnumerator CSpawnPattern4()
    {
        yield return new WaitForSeconds(1f);
        Obstacle obstacle1 = GetBasicObstacle(spawnPoses[2]);
        obstacle1.transform.rotation = rotatesDic[EDir.Left];

        yield return new WaitForSeconds(0.5f);
        Obstacle obstacle2 = GetSwingObstacle(spawnPoses[1]);
        obstacle2.transform.rotation = rotatesDic[EDir.Down];

    }

    private IEnumerator CSpawnPattern5()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSpinObstacle(spawnPoses[0]);

        yield return new WaitForSeconds(2f);
        Obstacle obstacle2 = GetBasicObstacle(spawnPoses[4]);
        obstacle2.transform.rotation = rotatesDic[EDir.Left];


        yield return new WaitForSeconds(1f);
        Obstacle obstacle3 = GetBasicObstacle(spawnPoses[1]);
        obstacle3.transform.rotation = rotatesDic[EDir.Right];
    }

    private IEnumerator CSpawnPattern6()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSwingObstacle(spawnPoses[2]);

        yield return new WaitForSeconds(2f);
        Obstacle obstacle2 = GetSpinObstacle(spawnPoses[4]);

        yield return new WaitForSeconds(3f);
        Obstacle obstacle3 = GetBasicObstacle(spawnPoses[0]);
        obstacle3.transform.rotation = rotatesDic[EDir.Up];
    }

    private IEnumerator CSpawnPattern7()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSwingObstacle(spawnPoses[0]);

        yield return new WaitForSeconds(3f);
        Obstacle obstacle2 = GetBasicObstacle(spawnPoses[4]);
        obstacle2.transform.rotation = rotatesDic[EDir.Left];
    }

    private IEnumerator CSpawnPattern8()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetBasicObstacle(spawnPoses[1]);
        obstacle1.transform.rotation = rotatesDic[EDir.Right];

        yield return new WaitForSeconds(2.5f);
        Obstacle obstacle2 = GetSwingObstacle(spawnPoses[3]);
    }

    private IEnumerator CSpawnPattern9()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSpinObstacle(spawnPoses[4]);

        yield return new WaitForSeconds(2f);
        Obstacle obstacle2 = GetBasicObstacle(spawnPoses[1]);
        obstacle2.transform.rotation = rotatesDic[EDir.Down];
    }

    private IEnumerator CSpawnPatten10()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSwingObstacle(spawnPoses[3]);
        obstacle1.transform.rotation = rotatesDic[EDir.Left];

        yield return new WaitForSeconds(2f);
        Obstacle obstacle2 = GetSwingObstacle(spawnPoses[1]);
    }

    private IEnumerator CSpawnPattern11()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetBasicObstacle(spawnPoses[0]);

        yield return new WaitForSeconds(2f);
        Obstacle obstacle2 = GetBasicObstacle(spawnPoses[4]);

        yield return new WaitForSeconds(3f);
        Obstacle obstacle3 = GetSwingObstacle(spawnPoses[1]);
    }

    private IEnumerator CSpawnPattern12()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSwingObstacle(spawnPoses[2]);

        yield return new WaitForSeconds(3f);
        Obstacle obstacle2 = GetSwingObstacle(spawnPoses[4]);
    }

    private IEnumerator CSpawnPattern13()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSpinObstacle(spawnPoses[3]);

        yield return new WaitForSeconds(3f);
        Obstacle obstacle2 = GetSpinObstacle(spawnPoses[0]);

    }

    private IEnumerator CSpawnPattern14()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetBasicObstacle(spawnPoses[1]);
        obstacle1.transform.rotation = rotatesDic[EDir.Left];

        yield return new WaitForSeconds(3f);
        Obstacle obstacle2 = GetSpinObstacle(spawnPoses[4]);
    }

    private IEnumerator CSpawnPattern15()
    {
        yield return new WaitForSeconds(2f);
        Obstacle obstacle1 = GetSwingObstacle(spawnPoses[2]);

        yield return new WaitForSeconds(3f);
        Obstacle obstacle = GetBasicObstacle(spawnPoses[3]);
    }

    //20����
    #endregion

    #region ��ֹ� �ҷ����� �Լ�
    private Obstacle GetBasicObstacle(Transform pos)
    {
        Obstacle obstacle = null;
        obstacle = ObjPool.Instance.GetObstacle(EObstacleType.Basic, pos.position);
        //obstacle.spriterenderer.sprite = obstacleSpriteDic[EObstacleType.Basic];
        return obstacle;
    }



    /// <summary>
    /// Swing
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private Obstacle GetSwingObstacle(Transform pos)
    {
        Obstacle obstacle = null;
        obstacle = ObjPool.Instance.GetObstacle(EObstacleType.Swing, pos.position);
        print(obstacle.obstacleType);
        //obstacle.spriterenderer.sprite = obstacleSpriteDic[EObstacleType.Swing];
        return obstacle;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private Obstacle GetSpinObstacle(Transform pos)
    {
        Obstacle obstacle = null;
        obstacle = ObjPool.Instance.GetObstacle(EObstacleType.Spin, pos.position);
        //obstacle.spriterenderer.sprite = obstacleSpriteDic[EObstacleType.Spin];
        return obstacle;
    }
    #endregion
}
