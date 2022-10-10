using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : Singleton<Player>
{
    #region Condition
    public bool isBoosting;
    public bool isMagneting;
    public bool isBig;
    #endregion

    [Tooltip("���� ������ Ÿ�� �ִ°�")]
    public EVehicleType vehicleType;

    private const float FORCE = 12f;

    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;

    [Tooltip("������ �ֳ�")]
    public bool isPressing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        InputKey(vehicleType);
        CurrentVehicle(vehicleType);
    }

    /// <summary>
    /// ���ư��� Ű �Է�(PC)
    /// </summary>
    private void InputKey(EVehicleType type)
    {
        switch (type)
        {
            case EVehicleType.None:
            case EVehicleType.Wyvern:
            case EVehicleType.Frog:
            case EVehicleType.BusterMachine:
                if (Input.GetKey(KeyCode.Space))
                {
                    isPressing = true;
                }
                else
                {
                    isPressing = false;
                }
                break;
            case EVehicleType.ProfitUFO:
            case EVehicleType.GravitySuit:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isPressing = true;
                }
                else
                {
                    isPressing = false;
                }
                break;
        }
                
    }

    private void CurrentVehicle(EVehicleType type)
    {
        switch (type)
        {
            case EVehicleType.None:
                Flying();
                break;
            case EVehicleType.GravitySuit:
                ChangeGravity();
                break;
            case EVehicleType.Wyvern:
                FlyingWyvern();
                break;
            case EVehicleType.ProfitUFO:

                break;
            case EVehicleType.BusterMachine:

                break;
            case EVehicleType.Frog:

                break;
        }
    }

    /// <summary>
    /// ���� ������~
    /// </summary>
    private void Flying()
    {
        if (isPressing == true)
        {
            rb.AddForce(Vector3.up * FORCE);
        }
    }

    /// <summary>
    /// �߷� �ٲٱ�
    /// </summary>
    private void ChangeGravity()
    {
        if(isPressing == true)
        {
            rb.gravityScale *= -1;
        }
    }

    /// <summary>
    /// ���̹����� ����
    /// </summary>
    private void FlyingWyvern()
    {
        if(isPressing == true)
        {
            rb.AddForce(Vector3.down * FORCE);
        }
    }
}