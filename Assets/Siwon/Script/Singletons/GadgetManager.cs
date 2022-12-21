using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GadgetManager : Singleton<GadgetManager>
{
    #region GadgetLists
    [Space(10f)]
    [Tooltip("gadgets")]
    public List<Gadget> gadgetList = new List<Gadget>();

    [Space(10f)]
    [Tooltip("Slot(2ĭ)")]
    public List<GadgetSlot> gadgetSlotList = new List<GadgetSlot>();

    [SerializeField]
    [Tooltip("�������Կ� �ִ� ��ư")]//�� ��ư���� 
    private List<Button> gadgetBtns = new List<Button>();

    [Space(10f)]
    [Tooltip("gadgetDatas")]
    public List<GadgetData> gadgetDataList = new List<GadgetData>();
    #endregion
    #region UIs
    [Header("UI Sprite")]
    [Space(15f)]
    [Tooltip("�����ϱ� �� ��ư UISprite")]
    public Sprite selectBtnSprite;
    [Tooltip("������ ��ư UISprite")]
    public Sprite selectedBtnSprite;

    [SerializeField]
    [Space(10f)]
    [Tooltip("���� ���� �� ������ ���")]
    private Button pauseBackBtn;//����� Ŭ���ҽ� ������� �����ؾ���

    [SerializeField]
    [Tooltip("���� ����2���� ������ �ִ� GameObject")]
    private GameObject slot;
    #endregion

    [Space(10f)]
    [Tooltip("���� ���õ� �ִ� ����")]
    public Gadget currentSelectGadget;

    [SerializeField]
    [Tooltip("���� UI�� ���� ���� �� SlotPos")]
    private Vector3 truePos;
    [SerializeField]
    [Tooltip("���� UI�� ���� ���� �� SlotPos")]
    private Vector3 falsePos;

    private Coroutine CselectGadgetSlot;

    private bool isPutOnMode;
    public bool IsPutOnMode
    {
        get => isPutOnMode;
        set
        {
            pauseBackBtn.gameObject.SetActive(isPutOnMode);
        }
    }

    private bool isShopActive;
    public bool IsShopActive
    {
        get => isShopActive;
        set
        {
            if (value == true)
            {
                slot.transform.position = truePos;
            }
            else
            {
                slot.transform.position = falsePos;
            }
        }
    }

    public void ApplyGadgetAbility(EGadgetType type)
    {
        switch (type)
        {
            case EGadgetType.None:
                //null
                
            case EGadgetType.GravityBelt:

                //�߷� ����
                break;
            case EGadgetType.SlowRocket:
                //�������� �ӵ� ����
                break;
            case EGadgetType.Magnet:
                //�ڼ� Ȱ��ȭ
                break;
            case EGadgetType.XrayGoggles:
                //...
                break;
        }
    }

    /// <summary>
    /// ���� �����Լ�
    /// </summary>
    public void ApplyGadget(Gadget gadget)
    {
        //gadgetSlotList
        if (TryApplyGadget(gadget.Data)) return;

        CselectGadgetSlot = StartCoroutine(CSelectGadgetSlot());
    }

    /// <summary>
    /// ���� ���� �õ� �Լ�
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private bool TryApplyGadget(GadgetData data)
    {
        for (int i = 0; i < gadgetSlotList.Count; i++)
        {
            //if (gadgetSlotList[i].Data == null)
            //{
            //    gadgetSlotList[i].Data = data;
            //    return true;
            //}
        }
        return false;
    }

    /// <summary>
    /// ���� ���Կ� �ִ� Data�� �ٲٴ� �Լ�
    /// </summary>
    /// <param name="data"></param>
    private void ChangeGadgetData(GadgetSlot slot)
    {

    }

    /// <summary>
    /// ���� ���Կ� �����Ͱ� �ִ��� Ȯ��
    /// </summary>
    private void CheckSlot()
    {
        
    }

    private IEnumerator CSelectGadgetSlot()
    {
        IsPutOnMode = true;
        yield return null;
    }
}
