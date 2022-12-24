using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackgroundTouchDot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Ease easeType;

    [Header("ȭ�� Ŭ��")]
    public Image screenClick;
    public Image screenPrevent;

    [Header("Ÿ��Ʋ")]
    public GameObject title;
    public GameObject haveCoin;
    public GameObject stopBtn;
    public GameObject mainBtn;
    public GameObject settingBtn;

    [Header("�ΰ���")]
    public GameObject ingame;

    [Header("���� ����")]
    public GameObject smokeBoomb;

    [Header("�÷��̾�")]
    public GameObject player;
    public float playerDistance;
    public float playerWaitTime;

    bool isStartClick = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine("BtnMove");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.Instance.IsGameStart == true)
            Player.Instance.isPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (GameManager.Instance.IsGameStart == true)
            Player.Instance.isPressing = false;
    }

    public IEnumerator BtnMove()
    {
        if (isStartClick == false)
        {
            int titleDistance = 1500;
            int mainBtnDistance = -1100;

            Vector2 settingPos = settingBtn.transform.localPosition;
            Vector2 stopPos = stopBtn.transform.localPosition;

            float time = 0.5f;
            float waitTime = 0.2f;

            isStartClick = true;
            screenPrevent.raycastTarget = true;
            screenClick.raycastTarget = false;

            UIManager.Instance.touchToStart.DOKill();
            UIManager.Instance.title.transform.DOKill();

            UIManager.Instance.touchToStart.DOFade(0, time);

            for (int i = 1; i <= 4; i++)
            {
                mainBtn.transform.GetChild(i).DOLocalMoveY(mainBtnDistance, time).SetEase(easeType);
                yield return new WaitForSeconds(waitTime);

                switch (i)
                {
                    case 1:
                        title.transform.DOLocalMoveY(titleDistance, time).SetEase(easeType);
                        settingBtn.transform.DOLocalMove(stopPos, time).SetEase(easeType);
                        haveCoin.transform.DOLocalMoveY(stopPos.y, time).SetEase(easeType);
                        break;

                    case 4:
                        stopBtn.transform.DOLocalMove(settingPos, time).SetEase(easeType);
                        ingame.transform.DOLocalMoveY(-170, time).SetEase(easeType);
                        mainBtn.transform.GetChild(0).DOLocalMoveY(mainBtnDistance, time).SetEase(easeType);
                        break;
                }
            }

            yield return new WaitForSeconds(1);
            smokeBoomb.SetActive(true);
            UIManager.Instance.firstBackGround.GetComponent<SpriteRenderer>().sprite
                = UIManager.Instance.brokenBackGround;
            player.transform.DOLocalMoveX(playerDistance, playerWaitTime);
            yield return new WaitForSeconds(playerWaitTime);
            screenPrevent.raycastTarget = false;
            screenClick.raycastTarget = true;
            GameManager.Instance.IsGameStart = true;
        }
    }
}
