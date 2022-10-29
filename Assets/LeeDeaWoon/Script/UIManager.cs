using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public GameObject gameruleWindow;
    public GameObject creditWindow;

    public Image bgmColor;
    public Image effectColor;

    public Button settingBtn;
    public Button cancelBtn;
    public Button bgmBtn;
    public Button effectBtn;
    public Button gameruleBtn;
    public Button creditBtn;

    public bool isBGMCheck;
    public bool isEffectCheck;
    public bool isRuleCheck;
    public bool isCreditCheck;

    [Header("�Ͻ�����")]
    public GameObject stopWindow;

    public Button stopBtn;
    public Button backBtn;
    public Button stopSettingBtn;
    public Button reGameBtn;

    public bool isStopCheck;

    void Start()
    {
        UI_Dot();

        isBGMCheck = true;
        isEffectCheck = true;

        Setting_Btns();
        Stop_Btns();
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
    public void Setting_Btns()
    {
        // ���� ��ư�� ������ ��
        settingBtn.onClick.AddListener(() =>
        {
            blackScreen.SetActive(true);

            settingWindow.transform.DOLocalMoveY(0, 0.5f).SetUpdate(true);
        });

        // ��� ��ư�� ������ ��
        cancelBtn.onClick.AddListener(() =>
        {
            int settingMovePos = 1570;
            int rightMovePos = 1723;
            float waitTime = 0.5f;

            Sequence sequence = DOTween.Sequence();

            if (isStopCheck == false)
            {
                gameruleWindow.transform.DOLocalMoveX(rightMovePos, waitTime).SetUpdate(true);
                creditWindow.transform.DOLocalMoveX(rightMovePos, waitTime).SetUpdate(true);

                sequence.Append(settingWindow.transform.DOLocalMoveY(settingMovePos, waitTime).SetUpdate(true))
                        .OnComplete(() =>
                        {
                            blackScreen.SetActive(false);
                            settingWindow.transform.DOLocalMoveX(0, 0).SetUpdate(true);
                        });
            }

            else
            {
                settingWindow.transform.DOLocalMoveY(settingMovePos, waitTime).SetUpdate(true);
                stopWindow.transform.DOLocalMoveX(0, waitTime).SetUpdate(true);
            }
        });

        // BGM ��ư�� ������ ��
        bgmBtn.onClick.AddListener(() =>
        {
            if (isBGMCheck == true)
            {
                isBGMCheck = false;
                bgmColor.DOColor(Color.gray, 0).SetUpdate(true);
                Debug.Log("BGM�� �������ϴ�");
            }
            else
            {
                isBGMCheck = true;
                bgmColor.DOColor(Color.white, 0).SetUpdate(true);
                Debug.Log("BGM�� �������ϴ�.");
            }
        });

        // ȿ���� ��ư�� ������ ��
        effectBtn.onClick.AddListener(() =>
        {
            if (isEffectCheck == true)
            {
                isEffectCheck = false;
                effectColor.DOColor(Color.gray, 0).SetUpdate(true);
                Debug.Log("Effect�� �������ϴ�");
            }
            else
            {
                isEffectCheck = true;
                effectColor.DOColor(Color.white, 0).SetUpdate(true);
                Debug.Log("Effect�� �������ϴ�.");
            }
        });

        // ���ӱ�Ģ ��ư�� ������ ��
        gameruleBtn.onClick.AddListener(() =>
        {
            float waitTime = 0.5f;
            int gameRuleMovePos = 1723;
            int settingMovePos = -720;

            if (isRuleCheck == true)
            {
                if (isCreditCheck == false)
                    settingWindow.transform.DOLocalMoveX(0, waitTime).SetUpdate(true);

                isRuleCheck = false;
                gameruleWindow.transform.DOLocalMoveX(gameRuleMovePos, waitTime).SetUpdate(true);
            }

            else
            {
                settingWindow.transform.DOLocalMoveX(settingMovePos, waitTime).SetUpdate(true);
                gameruleWindow.transform.DOLocalMoveX(-gameRuleMovePos, waitTime).SetUpdate(true);
                isRuleCheck = true;
            }
        });

        // ũ���� ��ư�� ������ ��
        creditBtn.onClick.AddListener(() =>
        {
            float waitTime = 0.5f;
            int creditMovePos = 1723;
            int settingMovePos = -720;

            if (isCreditCheck == true)
            {
                if (isRuleCheck == false)
                    settingWindow.transform.DOLocalMoveX(0, waitTime).SetUpdate(true);

                isCreditCheck = false;
                creditWindow.transform.DOLocalMoveX(creditMovePos, waitTime).SetUpdate(true);
            }

            else
            {
                isCreditCheck = true;
                creditWindow.transform.DOLocalMoveX(-creditMovePos, waitTime).SetUpdate(true);
                settingWindow.transform.DOLocalMoveX(settingMovePos, waitTime).SetUpdate(true);
            }
        });
    }
    #endregion

    public void Stop_Btns()
    {
        // �Ͻ����� ��ư�� ������ ��
        stopBtn.onClick.AddListener(() =>
        {
            float waitTime = 0.5f;
            int stopMovePos = 0;
            int settingMovePos = -720;
            int MusicMovePos = -45;
            Time.timeScale = 0;

            isStopCheck = true;
            blackScreen.SetActive(true);
            creditBtn.gameObject.SetActive(false);
            gameruleBtn.gameObject.SetActive(false);

            bgmBtn.transform.DOLocalMoveY(MusicMovePos, 0).SetUpdate(true);
            effectBtn.transform.DOLocalMoveY(MusicMovePos, 0).SetUpdate(true);

            stopWindow.transform.DOLocalMoveX(0, 0).SetUpdate(true);
            settingWindow.transform.DOLocalMoveX(settingMovePos, 0).SetUpdate(true);
            stopWindow.transform.DOLocalMoveY(stopMovePos, waitTime).SetUpdate(true);
        });

        // ���ư��� ��ư�� ������ ��
        backBtn.onClick.AddListener(() =>
        {
            float waitTime = 0.5f;
            int stopMovePos = 1450;
            int settingMovePos = 1570;

            Time.timeScale = 1;

            blackScreen.SetActive(false);

            stopWindow.transform.DOLocalMoveY(stopMovePos, waitTime).SetUpdate(true);
            settingWindow.transform.DOLocalMoveY(settingMovePos, waitTime).SetUpdate(true);
        });

        // ���� ��ư�� ������ ��
        stopSettingBtn.onClick.AddListener(() =>
        {
            float waitTime = 0.5f;
            int stopMovePos = 450;
            int settingMovePos = 0;

            stopWindow.transform.DOLocalMoveX(stopMovePos, waitTime).SetUpdate(true);
            settingWindow.transform.DOLocalMoveY(settingMovePos, waitTime).SetUpdate(true);
        });

        // �޴��� ��ư�� ������ ��
        reGameBtn.onClick.AddListener(() =>
        {
            DOTween.PauseAll();
            Time.timeScale = 1;
            SceneManager.LoadScene("Main");
        });
    }
}
