using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    public enum EITem
    {
        Transformation, //����
        Magnet,         //�ڼ�
        Piggybank,      //������
        Booster,        //�ν���
        Coinconverter,  //���κ�ȯ��
        Sizecontrol,    //ũ������
    }
    public EITem eITem;

    public bool itemTouch;
    private SpriteRenderer spriteRenderer;

    [Header("������ : ũ������")]
    public int sizeTime; //Ŀ���� �ð�
    public int waitingTime; //��ٸ� �ð�
    public Vector3 size = new Vector3(); //���ϴ� ������

    float invincibilityTimer;

    void Start()
    {
        itemTouch = false;
    }

    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (invincibilityTimer < waitingTime && itemTouch == true)
            invincibilityTimer += Time.deltaTime;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            itemTouch = true;

            switch (eITem)
            {
                case EITem.Transformation:

                    break;

                case EITem.Magnet: // �ڼ�
                    break;

                case EITem.Piggybank:
                    break;

                case EITem.Booster:
                    break;

                case EITem.Coinconverter:
                    break;

                case EITem.Sizecontrol: // ũ�� ����

                    if (invincibilityTimer <= waitingTime)
                    {
                        collision.transform.DOScale(size, sizeTime);
                        spriteRenderer.DOFade(0, 0);
                        // ��ֹ��� �ݶ��̴��� ���ֱ�

                        yield return new WaitForSeconds(waitingTime);
                        Destroy(this.gameObject);
                        itemTouch = false;
                        invincibilityTimer = 0;

                        collision.transform.DOScale(new Vector3(1, 1, 1), sizeTime);
                        // ��ֹ��� �ݶ��̴��� ���ֱ�
                    }
                    break;
            }

        }
    }
}
