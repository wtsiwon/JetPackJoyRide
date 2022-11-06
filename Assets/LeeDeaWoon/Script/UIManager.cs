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

    private float waitTime = 0.5f;

    [Header("Ÿ��Ʋ")]
    public GameObject title;
    public TextMeshProUGUI touchToStart;
    public TextMeshProUGUI haveCoin;

    [Header("�ΰ���")]
    public TextMeshProUGUI coin;
    public TextMeshProUGUI distance;

    [Header("����")]
    public GameObject shopWindow;

    public Button shopBtn;
    public Button characterBtn;
    public Button gadgetBtn;
    public Button vehicleBtn;
    public Button shopsCancelBtn;

    [Header("����")]
    public GameObject settingWindow;
    public GameObject blackScreen;
    public GameObject gameruleWindow;
    public GameObject creditWindow;

    public Image bgmColor;
    public Image effectColor;

    public Button settingBtn;
    public Button settingCancelBtn;
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

    [Header("���ӿ���")]
    public GameObject gameOverWindow;

    public Button gameOverMenuBtn;

    public TextMeshProUGUI gameOverCoin;
    public TextMeshProUGUI gameOverDistance;

    void Start()
    {
        isBGMCheck = true;
        isEffectCheck = true;

        UI_Dot();
        Stop_Btns();
        Setting_Btns();
        GameOver_Btn();
    }

    void Update()
    {
        coin.text = GameManager.Instance.coin.ToString();
        distance.text = GameManager.Instance.Distance.ToString();
        haveCoin.text = GameManager.Instance.haveCoin.ToString();
    }

    public void UI_Dot()
    {
        int move = 310;
        int touchWaitTime = 1;
        float titleWaitTime = 0.5f;

        touchToStart.DOFade(0, touchWaitTime).SetLoops(-1, LoopType.Yoyo);
        title.transform.DOLocalMoveY(move, titleWaitTime).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    #region ���ι�ư
    public void Main_Btn()
    {
        // ���� ��ư�� ������ ��
        shopBtn.onClick.AddListener(() =>
        {
            shopWindow.SetActive(true);
        });

        // ĳ���� ��ư�� ������ ��
        characterBtn.onClick.AddListener(() =>
        {
            shopWindow.SetActive(true);
        });

        // ���� ��ư�� ������ ��
        gadgetBtn.onClick.AddListener(() =>
        {
            shopWindow.SetActive(true);
        });

        // Ż�� ��ư�� ������ ��
        vehicleBtn.onClick.AddListener(() =>
        {
            shopWindow.SetActive(true);
        });

        // ������� ��ư�� ������ ��
        //shopsCancelBtn.onClick.AddListener(() =>
        //{
        //    shopWindow.SetActive(false);
        //});
    }


    #endregion

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
        settingCancelBtn.onClick.AddListener(() =>
        {
            int settingMovePos = 1570;
            int rightMovePos = 1723;

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

    #region �Ͻ����� â
    public void Stop_Btns()
    {
        // �Ͻ����� ��ư�� ������ ��
        stopBtn.onClick.AddListener(() =>
        {
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
    #endregion

    #region ���ӿ��� â
    public void GameOver()
    {
        Time.timeScale = 0;

        blackScreen.SetActive(true);

        gameOverCoin.text = $"���� : {GameManager.Instance.coin}";
        gameOverDistance.text = $"�Ÿ� : {GameManager.Instance.Distance}m";

        gameOverWindow.transform.DOLocalMoveY(0, waitTime).SetUpdate(true);
    }

    void GameOver_Btn()
    {
        gameOverMenuBtn.onClick.AddListener(() =>
        {
            DOTween.PauseAll();
            Time.timeScale = 1;

            SceneManager.LoadScene("Main");
        });
    }
    #endregion
}
