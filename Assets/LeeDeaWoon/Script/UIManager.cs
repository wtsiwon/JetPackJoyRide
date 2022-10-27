using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager inst;
    private void Awake() => inst = this;

    [Header("Ÿ��Ʋ")]
    public GameObject Title;
    public TextMeshProUGUI touchToStart;

    [Header("����")]
    public GameObject settingWindow;
    public GameObject blackScreen;

    public Image blackScreenTarget;
    public Image bgmColor;
    public Image effectColor;

    public bool isBGMCheck;
    public bool isEffectCheck;



    void Start()
    {
        UI_Dot();

        isBGMCheck = true;
        isEffectCheck = true;
    }

    void Update()
    {

    }

    public void UI_Dot()
    {
        int touchWaitTime = 1;

        int move = 310;
        float titleWaitTime = 0.5f;

        touchToStart.DOFade(0, touchWaitTime).SetLoops(-1, LoopType.Yoyo);
        Title.transform.DOLocalMoveY(move, titleWaitTime).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
    }


    #region ���� â
    public void Setting_Btn()
    {
        blackScreen.SetActive(true);
        blackScreenTarget.raycastTarget = true;

        settingWindow.transform.DOLocalMoveY(0, 0.5f);
    }

    public void Setting_Cancel()
    {
        blackScreen.SetActive(false);
        blackScreenTarget.raycastTarget = false;

        settingWindow.transform.DOLocalMoveY(1570, 0.5f);
    }
    
    public void Setting_BGM()
    {
        if (isBGMCheck == true)
        {
            isBGMCheck = false;
            bgmColor.DOColor(Color.gray, 0);
            Debug.Log("BGM�� �������ϴ�");
        }
        else
        {
            isBGMCheck = true;
            bgmColor.DOColor(Color.white, 0);
            Debug.Log("BGM�� �������ϴ�.");
        }
    }

    public void Setting_Effect()
    {
        if (isEffectCheck == true)
        {
            isEffectCheck = false;
            effectColor.DOColor(Color.gray, 0);
            Debug.Log("Effect�� �������ϴ�");
        }
        else
        {
            isEffectCheck = true;
            effectColor.DOColor(Color.white, 0);
            Debug.Log("Effect�� �������ϴ�.");
        }
    }

    public void Setting_Language()
    {

    }

    public void Setting_Credit()
    {

    }
    #endregion
}
