using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : Singleton<ObjPool>
{
    public EPoolType poolType;

    [SerializeField]
    [Tooltip("poolingObjs")]
    private PoolingObj[] originObjs;

    public Dictionary<EPoolType, Queue<PoolingObj>> pool = new Dictionary<EPoolType, Queue<PoolingObj>>();


    /// <summary>
    /// �������� �Լ�
    /// </summary>
    /// <param name="type"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    public PoolingObj Get(EPoolType type, Vector3 pos)
    {
        PoolingObj obj = null;

        if(pool.ContainsKey(type) == false)
        {
            pool.Add(type, new Queue<PoolingObj>());
        }
        Queue<PoolingObj> queue = pool[type];
        
        PoolingObj origin = originObjs[(int)type];

        if(queue.Count > 0)
        {
            obj = queue.Dequeue();
        }
        else
        {
            obj = Instantiate(origin);
        }
            
        obj.transform.position = pos;
        obj.gameObject.SetActive(true);
        
        return obj;
    }

    public void InitializeKey()
    {
        pool.Add(EPoolType.BackGround, new Queue<PoolingObj>());
    }

    /// <summary>
    /// ��ȯ���� ���� ���� �ʴ� Get�Լ�
    /// ���� BackGroundGet�� ������ �ʾƵ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    public T Get<T>(EPoolType type, Vector3 pos)
    {
        return Get(type,pos).GetComponent<T>();
    }

    /// <summary>
    /// ������ �������� �Լ�
    /// </summary>
    /// <param name="type"></param>
    /// <param name="pos"></param>
    public void GetItem(EItemType type, Vector3 pos)
    {
        Item item = null;
        item = Get(EPoolType.Item, pos).GetComponent<Item>();
        //ItemSprite�����ؾ���
    }

    /// <summary>
    /// ��ֹ� �������� �Լ�
    /// </summary>
    /// <param name="type"></param>
    /// <param name="pos"></param>
    public void GetObstacle(EObstacleType type, Vector3 pos)
    {
        Obstacle obstacle = null;
        obstacle = Get(EPoolType.Obstacle, pos).GetComponent<Obstacle>();

    }

    /// <summary>
    /// Effect ���������Լ�
    /// </summary>
    /// <param name="type"></param>
    /// <param name="pos"></param>
    public void GetEffect(EEffectType type, Vector3 pos)
    {
        Effector2D effect = null;
        effect = Get(EPoolType.Effect, pos).GetComponent<Effector2D>();
    }

    /// <summary>
    /// ���� �������� �Լ�
    /// </summary>
    /// <param name="type"></param>
    /// <param name="pos"></param>
    public void GetSound(ESoundType type, Vector3 pos)
    {
        
    }


    /// <summary>
    /// �ٽ� Ǯ�� �ִ� �Լ�
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    public void Return(EPoolType type, PoolingObj obj)
    { 
        obj.gameObject.SetActive(false);
        pool[type].Enqueue(obj);
    }
}
