using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ETheme//�׸�
{

}
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BackGround : PoolingObj
{
    private const float SCROLLXPOS = -21f;


    private void Update()
    {
        //�Ÿ���� �ӵ�����
        if(transform.position.x < SCROLLXPOS)
        {
            Return();
        }
    }

    private void OnEnable()
    {
        
    }

    
    public override void Return()
    {
        base.Return();

    }
}
