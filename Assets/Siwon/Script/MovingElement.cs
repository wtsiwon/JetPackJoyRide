using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ΰ��� �����̴� ��ҵ�
[RequireComponent(typeof(Rigidbody2D))]
public class MovingElement : PoolingObj
{
    protected Rigidbody2D rb;

    [HideInInspector]
    public SpriteRenderer spriterenderer;

    private Time time;
    public Time Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
            if (time.Equals(1))
            {
                rb.velocity = Vector3.left * 1f;
            }
        }
    }
    
    protected virtual void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * BackGroundSpawner.Instance.backgroundSpd;
    }

    protected virtual void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    
}
