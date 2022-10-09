using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum EITem
    {
        Transformation, // ����
        Magnet,         // �ڼ�
        Piggybank,      // ������
        Booster,        // �ν���
        Coinconverter,  // ���κ�ȯ��
        Sizecontrol,    // ũ������
    }
    public EITem eITem;

    [Header("������ : ũ������")]
    float invincibilityTimer;
    public int waitingTime;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (eITem)
        {
            case EITem.Transformation:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    this.GetComponent<BoxCollider2D>().enabled = false;
                }
                break;

            case EITem.Magnet:
                break;

            case EITem.Piggybank:
                break;

            case EITem.Booster:
                break;

            case EITem.Coinconverter:
                break;

            case EITem.Sizecontrol:
                collision.transform.localScale *= 2.5f;

                invincibilityTimer += Time.deltaTime;
                if (invincibilityTimer < waitingTime)
                {
                    collision.GetComponent<CapsuleCollider2D>().enabled = false;
                }
                else
                {
                    collision.GetComponent<CapsuleCollider2D>().enabled = true;
                    invincibilityTimer = 0f;
                }
                break;
        }
    }
}
