using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : AbstractItem
{
    [Header("������ : ������")]
    [Tooltip("���� ������ ��")]
    public int getCoin;
    
    protected override IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        return base.OnTriggerEnter2D(collision);
        if(collision is Player)
        {
            //EffectManager�� �ٲ����
            Instantiate(ItemManager.inst.piggybankDirector, Vector2.zero, Quaternion.identity).transform.SetParent(gameObject.transform, false);
            UIManager.Instance.coin += getCoin;
            GameManager.Instance.haveCoin += getCoin;
        }
    }
}
