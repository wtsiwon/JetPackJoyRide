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
    public Button reGameBtn;

    WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(0.01f);

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

            blackScreen.SetActive(false);

            settingWindow.transform.DOLocalMoveY(settingMovePos, waitTime).SetUpdate(true);
            gameruleWindow.transform.DOLocalMoveX(rightMovePos, waitTime).SetUpdate(true);
            creditWindow.transform.DOLocalMoveX(rightMovePos, waitTime).SetUpdate(true);
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
            int MovePos = 1723;
            float waitTime = 0.5f;

            if (isRuleCheck == true)
            {
                gameruleWindow.transform.DOLocalMoveX(MovePos, waitTime).SetUpdate(true);
                isRuleCheck = false;
            }

            else
            {
                gameruleWindow.transform.DOLocalMoveX(-MovePos, waitTime).SetUpdate(true);
                isRuleCheck = true;
            }
        });

        // ũ���� ��ư�� ������ ��
        creditBtn.onClick.AddListener(() =>
        {
            int MovePos = 1723;
            float waitTime = 0.5f;

            if (isCreditCheck == true)
            {
                isCreditCheck = false;
                creditWindow.transform.DOLocalMoveX(MovePos, waitTime).SetUpdate(true);
            }

            else
            {
                isCreditCheck = true;
                creditWindow.transform.DOLocalMoveX(-MovePos, waitTime).SetUpdate(true);
            }
        });
    }
    #endregion

    public void Stop_Btns()
    {
        // �Ͻ����� ��ư�� ������ ��
        stopBtn.onClick.AddListener(() =>
        {
            int movePos = 0;
            float waitTime = 0.5f;

            Time.timeScale = 0;

            blackScreen.SetActive(true);

            stopWindow.transform.DOLocalMoveY(movePos, waitTime).SetUpdate(true);
        });

        // ���ư��� ��ư�� ������ ��
        backBtn.onClick.AddListener(() =>
        {
            int movePos = 1450;
            float waitTime = 0.5f;

            Time.timeScale = 1;

            blackScreen.SetActive(false);

            stopWindow.transform.DOLocalMoveY(movePos, waitTime).SetUpdate(true);
        });

        reGameBtn.onClick.AddListener(() =>
        {
            DOTween.PauseAll();
            SceneManager.LoadScene("Main");
        });
    }
}
