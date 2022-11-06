using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Item : MovingElement
{
    public EItemType itemType;

    public new Collider2D collider2D;

    [Header("������ : �ν���")]
    public float boosterDuration; // ���ӽð�
    public float boosterSpeed; // �ӷ�
    public Ease ease;

    [Header("������ : �ڼ�")]
    public int magnetWaitingTime; // ��ٸ� �ð�

    float magnetTimer;

    [Header("������ : ������")]
    public GameObject piggybankCoin; // ��ȯ�� ������ ����

    [Header("������ : ũ������")]
    public int sizeTime; //Ŀ���� �ð�
    public int sizeWaitingTime; //��ٸ� �ð�
    public Vector2 playerSize;

    float sizeTimer;

    protected override void Start()
    {
        base.Start();
        collider2D = GetComponent<Collider2D>();

        playerSize = Player.Instance.transform.localScale;
    }

    void Update()
    {
        Item_Delay();
    }

    // ������ ������
    void Item_Delay()
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
            spriterenderer.DOFade(0, 0);

            switch (itemType)
            {
                case EItemType.Transformation:

                    break;


                case EItemType.Magnet: // �ڼ�

                    Player.Instance.isMagneting = true;
                    yield return new WaitForSeconds(magnetWaitingTime);
                    Destroy(this.gameObject);
                    Player.Instance.isMagneting = false;
                    magnetTimer = 0;

                    break;


                case EItemType.Piggybank: // ������
                    float posMinX = 3f;
                    float posMaxX = 6f;

                    float posMinY = 1f;
                    float posMaxY = 2f;

                    GameObject bankCoinPattern = Instantiate(piggybankCoin, new Vector2(transform.position.x + Random.Range(posMinX, posMaxX), transform.position.y + Random.Range(posMinY, posMaxY)), Quaternion.identity);
                    bankCoinPattern.transform.parent = gameObject.transform;
                    bankCoinPattern.GetComponent<Rigidbody2D>().velocity = Vector3.left * BackGroundSpawner.Instance.backgroundSpd;

                    break;


                case EItemType.Booster: // �ν���
                    Sequence mySequence = DOTween.Sequence();
                    float playerXValue = collision.transform.position.x;

                    mySequence.Append(collision.transform.DOLocalMoveX(-8, 2f))
                              .OnComplete(() =>
                              {
                                  Player.Instance.boosterType = EBoosterType.BoosterItem;
                                  Player.Instance.isBoosting = true;
                                  collision.transform.DOLocalMoveX(-0.9f, boosterSpeed);
                              });
                    yield return new WaitForSeconds(boosterDuration); // ���ӽð�

                    collision.transform.DOLocalMoveX(playerXValue, boosterSpeed);

                    Player.Instance.isBoosting = false;
                    yield return new WaitForSeconds(boosterSpeed);

                    Destroy(this.gameObject);
                    break;


                case EItemType.Coinconverter:
                    break;


                case EItemType.Sizecontrol: // ũ�� ����

                    Player.Instance.isBig = true;
                    collision.transform.DOScale(new Vector2(playerSize.x + 0.2f, playerSize.y + 0.2f), sizeTime);
                    // ��ֹ��� �ݶ��̴��� ���ֱ�

                    yield return new WaitForSeconds(sizeWaitingTime);
                    Destroy(this.gameObject);
                    Player.Instance.isBig = false;
                    sizeTimer = 0;

                    collision.transform.DOScale(playerSize, sizeTime);
                    // ��ֹ��� �ݶ��̴��� ���ֱ�
                    break;
            }

        }
    }
}
