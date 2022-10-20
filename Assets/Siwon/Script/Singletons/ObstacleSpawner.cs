using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleSpawner : Singleton<ObstacleSpawner>
{
    [SerializeField]
    [Tooltip("��ֹ��� ��ȯ�� ��ġ��")]
    private List<Transform> spawnPoses = new List<Transform>();

    [Tooltip("��ֹ� ���� �Լ���")]
    public List<Action> obstaclePatterns = new List<Action>();

    [Tooltip("���� ���� ��� Dictionary")]
    private Dictionary<EDir, Quaternion> rotatesDic = new Dictionary<EDir, Quaternion>();

    [Tooltip("��ֹ� Sprite�� enumŸ�Կ� ���� �з��� dictionary")]
    private Dictionary<EObstacleType, Sprite> obstacleSpriteDic = new Dictionary<EObstacleType, Sprite>();

    [Tooltip("��ֹ� Sprite��List")]
    [Space(15f)]
    public List<Sprite> obstacleSpriteList = new List<Sprite>();

    private void Start()
    {
        AddRotates();
        AddObstaclePattern();
        AddObstacleSprite();
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
    /// Action�� ��ֹ� ���� �Լ� �߰��ϴ� �Լ�
    /// </summary>
    private void AddObstaclePattern()
    {
        obstaclePatterns.Add(SpawnPattern1);

    }

    private void SpawnPattern1()
    {
        StartCoroutine(CSpawnPattern1());
    }

    private void SpawnPattern2()
    {

    }

    private IEnumerator CSpawnPattern1()
    {
        yield return new WaitForSeconds(1f);
        Obstacle obstacle1 = GetBasicObstacle(spawnPoses[1]);
        obstacle1.transform.rotation = rotatesDic[EDir.Up];


        yield return new WaitForSeconds(1f);
        Obstacle obstacle2 = GetSwingObstacle(spawnPoses[5]);


        yield return new WaitForSeconds(1f);




    }

    private Obstacle GetBasicObstacle(Transform pos)
    {
        Obstacle obstacle = null;
        obstacle = ObjPool.Instance.GetObstacle(EObstacleType.Basic, pos.position);
        obstacle.spriterenderer.sprite = obstacleSpriteDic[EObstacleType.Basic];
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
        obstacle.spriterenderer.sprite = obstacleSpriteDic[EObstacleType.Swing];
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
        obstacle.spriterenderer.sprite = obstacleSpriteDic[EObstacleType.Spin];
        return obstacle;
    }





}
