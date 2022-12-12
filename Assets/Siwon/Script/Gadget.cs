using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Gadget : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���� ������")]
    private Image icon;

    [Header("TextMeshPros")]
    [Space(15f)]
    [SerializeField]
    [Tooltip("������ �̸�Text")]
    private TextMeshProUGUI nameTxt;

    [SerializeField]
    [Tooltip("������ ���� ����Text")]
    private TextMeshProUGUI explainTxt;

    [SerializeField]
    [Tooltip("������ ����Text ���Ž� ��Ȱ��ȭ")]
    private TextMeshProUGUI costTxt;

    [Header("Buttons")]
    [Space(15f)]
    [SerializeField]
    private Button buyBtn;

    [SerializeField]
    [Tooltip("���� �����ϴ� ��ưBtn")]
    private Button selectBtn;

    [Tooltip("�� ������ �����Ǿ� �ִ°�")]
    [Space(10f)]
    private bool isSelected;
    public bool IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;
            if (value == true)
            {
                //�����Ǿ��ٸ� ���ÿϷ� Sprite�� ����
                selectBtn.GetComponent<Image>().sprite
                    = GadgetManager.Instance.selectedBtnSprite;

                GadgetManager.Instance.ApplyGadget(this);
            }
            else
            {
                //���� ������ �Ǿ����� ���� Sprite�� ����
                selectBtn.GetComponent<Image>().sprite
                    = GadgetManager.Instance.selectBtnSprite;
            }
        }
    }

    public bool IsBought
    {
        get => data.isBought;
        set
        {
            data.isBought = value;
            print(data.isBought);
            buyBtn.gameObject.SetActive(false);
            selectBtn.gameObject.SetActive(true);
            GadgetManager.Instance.ApplyGadget(this);
        }
    }

    [SerializeField]
    [Tooltip("������ �ʿ��� ����Data")]
    private GadgetData data;

    public GadgetData Data
    {
        get => data;
        set
        {
            data = value;
        }
    }

    private void Start()
    {
        Debug.Assert(selectBtn != null, "SelectBtn is null");
        buyBtn.onClick.AddListener(() =>
        {
            IsBought = true;
            print("buyBtn");
            if (GameManager.Instance.haveCoin >= data.cost)
            {
                IsBought = true;
            }
        });

        Debug.Assert(selectBtn != null, "SelectBtn is null");
        selectBtn.onClick.AddListener(() =>
        {
            print("selctcBtn");
            if (IsBought == true)
            {
                if (IsSelected == false)
                {
                    IsSelected = true;
                }
                else
                {
                    IsSelected = false;
                }
            }
        });
    }

    private void OnEnable()
    {
        SetGadgetUI();
    }

    /// <summary>
    /// GadgetUI Setting
    /// </summary>
    private void SetGadgetUI()
    {
        costTxt.text = data.cost.ToString("F0");
        nameTxt.text = data.name;
        explainTxt.text = data.explain;
    }
    //���ʷ� �� ��UI������ �ؾ� �ұ�
    //�׳� ó������ ������

}
