using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackgroundTouchDot : MonoBehaviour, IPointerClickHandler
{
    public Ease easeType;

    [Header("ȭ�� Ŭ��")]
    public Image screenClick;

    [Header("UI ��ư")]
    public GameObject mainBtn;

    [Header("Ÿ��Ʋ")]
    public GameObject Title;

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

    public IEnumerator BtnMove()
    {
        if (isStartClick == false)
        {
            screenClick.raycastTarget = false;
            isStartClick = true;

            int btnDistance = -1100;
            int titleDistance = 1250;

            float time = 0.5f;
            float waitTime = 0.2f;

            UIManager.inst.touchToStart.DOKill();
            UIManager.inst.Title.transform.DOKill();

            UIManager.inst.touchToStart.DOFade(0, time);

            for (int i = 1; i <= 4; i++)
            {

                mainBtn.transform.GetChild(i).DOLocalMoveY(btnDistance, time).SetEase(easeType);
                yield return new WaitForSeconds(waitTime);

                switch (i)
                {
                    case 1:
                        Title.transform.DOLocalMoveY(titleDistance, time).SetEase(easeType);
                        break;

                    case 4:
                        mainBtn.transform.GetChild(0).DOLocalMoveY(btnDistance, time).SetEase(easeType);
                        break;
                }
            }

            yield return new WaitForSeconds(1);
            smokeBoomb.SetActive(true);
            player.transform.DOLocalMoveX(playerDistance, playerWaitTime);
            yield return new WaitForSeconds(playerWaitTime);
            GameManager.Instance.isGameStart = true;
        }
    }
}
