using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake() => Instance = this;

    private float waitTime = 0.5f;

    [Header("Ÿ��Ʋ")]
    public GameObject title;
    public GameObject firstBackGround;
    public TextMeshProUGUI touchToStart;
    public TextMeshProUGUI haveCoin;
    public Sprite brokenBackGround;

    [Header("�ΰ���")]
    public int coin;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI distanceText;

    #region ����
    [Header("����")]
    public List<Shop> itemShop = new List<Shop>();
    [SerializeField] GameObject shopWindow;
    [SerializeField] GameObject content;

    [SerializeField] Button shopBtn;
    [SerializeField] Button characterBtn;
    [SerializeField] Button gadgetBtn;
    [SerializeField] Button vehicleBtn;
    [SerializeField] Button shopsCancelBtn;
    [SerializeField] TextMeshProUGUI haveShopCoin;


    [Space(10)]
    [SerializeField] GameObject purchaseWindow;
    [SerializeField] Image purchaseItemIcon;

    [SerializeField] Button reductionBtn;
    [SerializeField] Button increaseBtn;
    [SerializeField] Button purchaseCancelBtn;
    [SerializeField] Button purchaseBtn;

    [SerializeField] TextMeshProUGUI quantityText;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] TextMeshProUGUI totalPriceText;

    int shopQuantity;
    int shopPrice;
    int shopItemNumber;
    #endregion

    #region ����
    [Header("����")]
    [SerializeField] GameObject settingWindow;
    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject creditWindow;

    [SerializeField] Image bgmColor;
    [SerializeField] Image effectColor;

    [SerializeField] Button settingBtn;
    [SerializeField] Button settingCancelBtn;
    [SerializeField] Button bgmBtn;
    [SerializeField] Button effectBtn;
    [SerializeField] Button gameruleBtn;
    [SerializeField] Button creditBtn;

    public bool isCreditCheck;
    #endregion

    #region �Ͻ�����
    [Header("�Ͻ�����")]
    [SerializeField] GameObject stopWindow;

    public Button stopBtn;
    [SerializeField] Button backBtn;
    [SerializeField] Button stopSettingBtn;
    [SerializeField] Button reGameBtn;

    public bool isStopCheck;
    #endregion

    #region ���ӿ���
    [Header("���ӿ���")]
    [SerializeField] GameObject gameOverWindow;

    [SerializeField] Button gameOverMenuBtn;

    [SerializeField] TextMeshProUGUI gameOverCoin;
    [SerializeField] TextMeshProUGUI gameOverDistance;
    #endregion

    void Start()
    {
        DOTween.PauseAll();
        Time.timeScale = 1;

        UI_Dot();
        Stop_Btns();
        Main_Btns();
        Shop_Btns();
        Setting_Btns();
        GameOver_Btn();

        if (SoundManager.instance.isBGMCheck == false)
            bgmColor.DOColor(Color.gray, 0).SetUpdate(true);
        else
            bgmColor.DOColor(Color.white, 0).SetUpdate(true);

        if (SoundManager.instance.isEffectCheck == false)
            effectColor.DOColor(Color.gray, 0).SetUpdate(true);
        else
            effectColor.DOColor(Color.white, 0).SetUpdate(true);
    }

    void Update()
    {
        distanceText.text = $"{GameManager.Instance.Distance.ToString("F0")}m";

        coinText.text = coin.ToString();
        haveCoin.text = GameManager.Instance.haveCoin.ToString();
        haveShopCoin.text = GameManager.Instance.haveCoin.ToString();

        quantityText.text = shopQuantity.ToString();
        priceText.text = itemShop[shopItemNumber].itemPirce.ToString();
        totalPriceText.text = (itemShop[shopItemNumber].itemPirce * shopQuantity).ToString();
        purchaseItemIcon.sprite = itemShop[shopItemNumber].itemIcon.sprite;

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
    public void Main_Btns()
    {
        // ���� ��ư�� ������ ��
        shopBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            shopWindow.SetActive(true);
            content.transform.GetChild(0).gameObject.SetActive(true);
        });

        // ĳ���� ��ư�� ������ ��
        characterBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            shopWindow.SetActive(true);
            content.transform.GetChild(1).gameObject.SetActive(true);
        });

        // ���� ��ư�� ������ ��
        gadgetBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            shopWindow.SetActive(true);
            content.transform.GetChild(2).gameObject.SetActive(true);
        });

        // Ż�� ��ư�� ������ ��
        vehicleBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            shopWindow.SetActive(true);
            content.transform.GetChild(3).gameObject.SetActive(true);
        });
    }


    #endregion

    #region ���� â
    public void Setting_Btns()
    {
        // ���� ��ư�� ������ ��
        settingBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            blackScreen.SetActive(true);

            settingWindow.transform.DOLocalMoveY(0, 0.5f).SetUpdate(true);
        });

        // ��� ��ư�� ������ ��
        settingCancelBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);

            int settingMovePos = 1570;
            int rightMovePos = 1723;

            Sequence sequence = DOTween.Sequence();

            if (isStopCheck == false)
            {
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
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);

            if (SoundManager.instance.isBGMCheck == true)
            {
                SoundManager.instance.isBGMCheck = false;

                SoundManager.instance.StopSoundClip(SoundType.BGM);
                bgmColor.DOColor(Color.gray, 0).SetUpdate(true);
                Debug.Log("BGM�� �������ϴ�");
            }
            else
            {
                SoundManager.instance.isBGMCheck = true;

                if (GameManager.Instance.IsGameStart == false)
                    SoundManager.instance.PlaySoundClip("MainScene", SoundType.BGM);
                else
                    SoundManager.instance.PlaySoundClip("DiamondRush", SoundType.BGM);

                bgmColor.DOColor(Color.white, 0).SetUpdate(true);
                Debug.Log("BGM�� �������ϴ�.");
            }
        });

        // ȿ���� ��ư�� ������ ��
        effectBtn.onClick.AddListener(() =>
        {

            if (SoundManager.instance.isEffectCheck == true)
            {
                SoundManager.instance.isEffectCheck = false;

                SoundManager.instance.audioSourceClasses[SoundType.SFX].audioSource.volume = 0;
                effectColor.DOColor(Color.gray, 0).SetUpdate(true);
                Debug.Log("Effect�� �������ϴ�");
            }
            else
            {
                SoundManager.instance.isEffectCheck = true;

                SoundManager.instance.audioSourceClasses[SoundType.SFX].audioSource.volume = 1;
                SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
                effectColor.DOColor(Color.white, 0).SetUpdate(true);
                Debug.Log("Effect�� �������ϴ�.");
            }
        });

        // Ʃ�丮�� ��ư�� ������ ��
        gameruleBtn.onClick.AddListener(() =>
        {
            DOTween.KillAll();

            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            SceneManager.LoadScene("Tutorial");
        });

        // ũ���� ��ư�� ������ ��
        creditBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);

            int creditMovePos = 1723;
            int settingMovePos = -720;

            if (isCreditCheck == true)
            {
                isCreditCheck = false;
                creditWindow.transform.DOLocalMoveX(creditMovePos, waitTime).SetUpdate(true);
                settingWindow.transform.DOLocalMoveX(0, waitTime).SetUpdate(true);
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
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);

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
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);

            int stopMovePos = 1800;
            int settingMovePos = 1800;

            Time.timeScale = 1;

            blackScreen.SetActive(false);

            stopWindow.transform.DOLocalMoveY(stopMovePos, waitTime).SetUpdate(true);
            settingWindow.transform.DOLocalMoveY(settingMovePos, waitTime).SetUpdate(true);
        });

        // ���� ��ư�� ������ ��
        stopSettingBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);

            int stopMovePos = 450;
            int settingMovePos = 0;

            stopWindow.transform.DOLocalMoveX(stopMovePos, waitTime).SetUpdate(true);
            settingWindow.transform.DOLocalMoveY(settingMovePos, waitTime).SetUpdate(true);
        });

        // �޴��� ��ư�� ������ ��
        reGameBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);

            DOTween.PauseAll();
            Time.timeScale = 1;

            GameManager.Instance.IsGameStart = false;

            SceneManager.LoadScene("Main");
        });
    }
    #endregion

    #region ���� ��ư
    public void Shop_Btns()
    {
        //����â ��ҹ�ư�� ������ ��
        purchaseCancelBtn.onClick.AddListener(() =>
        {

            purchaseWindow.SetActive(false);
        });

        purchaseBtn.onClick.AddListener(() =>
        {
            if (shopQuantity > 0)
            {
                Debug.Log(itemShop[shopItemNumber].itemName + "�� " + shopQuantity + "�� �����ϼ̽��ϴ�.");
                purchaseWindow.SetActive(false);
            }
            else
                Debug.Log("������ �������ּ���.");
        });

        //���� ��ư�� ������ ��
        reductionBtn.onClick.AddListener(() =>
        {
            int min = 0;

            if (shopQuantity > min)
                --shopQuantity;
            else
                Debug.Log("�ּ� �����Դϴ�.");
        });

        //���� ��ư�� ������ ��
        increaseBtn.onClick.AddListener(() =>
        {
            int max = 99;
            if (shopQuantity < max)
                ++shopQuantity;
            else
                Debug.Log("�ִ� �����Դϴ�.");
        });

        //������� ��ư�� ������ ��
        shopsCancelBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            shopWindow.SetActive(false);

            for (int i = 0; i < 4; i++)
                content.transform.GetChild(i).gameObject.SetActive(false);

        });
    }

    public void PurchaseBtn(int number)
    {
        shopPrice = 0;
        shopQuantity = 0;

        shopItemNumber = number;
        purchaseWindow.SetActive(true);
    }
    #endregion

    #region ���ӿ��� â
    public void GameOver()
    {
        SoundManager.instance.PlaySoundClip("GameOver", SoundType.SFX, SoundManager.instance.soundSFX + 0.5f);
        Time.timeScale = 0f;

        blackScreen.SetActive(true);

        gameOverCoin.text = $"���� : {coin}";
        gameOverDistance.text = $"�Ÿ� : {GameManager.Instance.Distance.ToString("F0")}m";

        gameOverWindow.transform.DOLocalMoveY(0, waitTime).SetUpdate(true);
        SoundManager.instance.StopSoundClip(SoundType.BGM);
    }

    void GameOver_Btn()
    {
        gameOverMenuBtn.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySoundClip("ButtonClick", SoundType.SFX, SoundManager.instance.soundSFX);
            SoundManager.instance.StopSoundClip(SoundType.BGM);

            DOTween.PauseAll();
            Time.timeScale = 1;

            GameManager.Instance.IsGameStart = false;
            SceneManager.LoadScene("Main");
        });
    }
    #endregion
}
