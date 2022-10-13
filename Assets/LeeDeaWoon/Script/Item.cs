using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : PoolingObj
{
    public enum EItem
    {
        Transformation, //����
        Magnet,         //�ڼ�
        Piggybank,      //������
        Booster,        //�ν���
        Coinconverter,  //���κ�ȯ��
        Sizecontrol,    //ũ������
    }
    public EItem eItem;

    public new Collider2D collider2D;
    public SpriteRenderer spriteRenderer;
    private Vector2 playerDistance;

    [Header("������ : �ν���")]
    public float boosterDuration; // ���ӽð�
    public float boosterDistance; // �Ÿ�
    public float boosterSpeed; // ����ӵ�
    public Ease ease;

    [Header("������ : �ڼ�")]
    public int magnetWaitingTime; // ��ٸ� �ð�

    float magnetTimer;

    [Header("������ : ������")]
    public GameObject piggybankCoin; // ��ȯ�� ������ ����
    public int coinCountMax; // �ִ� ����

    [Header("������ : ũ������")]
    public int sizeTime; //Ŀ���� �ð�
    public int sizeWaitingTime; //��ٸ� �ð�
    public Vector2 size = new Vector2(); //���ϴ� ������

    float sizeTimer;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerDistance.x = Player.Instance.transform.position.x;
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
            collider2D.enabled = false;
            spriteRenderer.DOFade(0, 0);

            int randX = Random.Range(0, 2);
            int randY = Random.Range(0, 2);

            switch (eItem)
            {
                case EItem.Transformation:

                    break;


                case EItem.Magnet: // �ڼ�

                    Player.Instance.isMagneting = true;

                    yield return new WaitForSeconds(magnetWaitingTime);
                    Destroy(this.gameObject);
                    Player.Instance.isMagneting = false;
                    magnetTimer = 0;

                    break;


                case EItem.Piggybank: // ������
                    for (int i = 0; i < coinCountMax; i++)
                        Instantiate(piggybankCoin, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
                    break;


                case EItem.Booster: // �ν���

                    Player.Instance.isBoosting = true;
                    collision.transform.DOLocalMoveX(boosterDistance, boosterSpeed).SetEase(ease);
                    yield return new WaitForSeconds(boosterDuration);
                    collision.transform.DOLocalMoveX(playerDistance.x, boosterSpeed).SetEase(ease);
                    yield return new WaitForSeconds(boosterSpeed);
                    Destroy(this.gameObject);
                    break;


                case EItem.Coinconverter:
                    break;


                case EItem.Sizecontrol: // ũ�� ����

                    Player.Instance.isBig = true;
                    collision.transform.DOScale(size, sizeTime);
                    // ��ֹ��� �ݶ��̴��� ���ֱ�

                    yield return new WaitForSeconds(sizeWaitingTime);
                    Destroy(this.gameObject);
                    Player.Instance.isBig = false;
                    sizeTimer = 0;

                    collision.transform.DOScale(new Vector2(1, 1), sizeTime);
                    // ��ֹ��� �ݶ��̴��� ���ֱ�
                    break;
            }

        }
    }
}
