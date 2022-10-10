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

    private SpriteRenderer spriteRenderer;

    [Header("������ : �ڼ�")]
    public int magnetWaitingTime; // ��ٸ� �ð�

    float magnetTimer;


    [Header("������ : ũ������")]
    public int sizeTime; //Ŀ���� �ð�
    public int sizeWaitingTime; //��ٸ� �ð�
    public Vector3 size = new Vector3(); //���ϴ� ������

    float sizeTimer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        Item_Delay();
    }


    // ������ ������
    public void Item_Delay()
    {
        if (sizeTimer < sizeWaitingTime && Player.Instance.isBig == true)
            sizeTimer += Time.deltaTime;

        if (magnetTimer < magnetWaitingTime && Player.Instance.isMagneting == true)
            magnetTimer += Time.deltaTime;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (eITem)
            {
                case EITem.Transformation:

                    break;


                case EITem.Magnet: // �ڼ�

                    Player.Instance.isMagneting = true;
                    spriteRenderer.DOFade(0, 0);

                    yield return new WaitForSeconds(magnetWaitingTime);
                    Destroy(this.gameObject);
                    Player.Instance.isMagneting = false;
                    magnetTimer = 0;

                    break;


                case EITem.Piggybank:
                    break;


                case EITem.Booster:
                    break;


                case EITem.Coinconverter:
                    break;


                case EITem.Sizecontrol: // ũ�� ����

                    Player.Instance.isBig = true;
                    collision.transform.DOScale(size, sizeTime);
                    spriteRenderer.DOFade(0, 0);
                    // ��ֹ��� �ݶ��̴��� ���ֱ�

                    yield return new WaitForSeconds(sizeWaitingTime);
                    Destroy(this.gameObject);
                    Player.Instance.isBig = false;
                    sizeTimer = 0;

                    collision.transform.DOScale(new Vector3(1, 1, 1), sizeTime);
                    // ��ֹ��� �ݶ��̴��� ���ֱ�
                    break;
            }

        }
    }
}
