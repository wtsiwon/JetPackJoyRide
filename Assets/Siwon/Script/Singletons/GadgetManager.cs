using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManager : Singleton<GadgetManager>
{
    [Tooltip("gadgets")]
    public List<Gadget> gadgetList = new List<Gadget>();

    [Tooltip("Slot(2ĭ)")]
    public List<GadgetSlot> gadgetSlotList = new List<GadgetSlot>();

    [Tooltip("gadgetDatas")]
    public List<GadgetData> gadgetDataList = new List<GadgetData>();

    [Tooltip("�����ϱ� �� ��ư UI")]
    public Sprite selectBtnSprite;
    [Tooltip("������ ��ư UI")]
    public Sprite selectedBtnSprite;

    /// <summary>
    /// ���� �����Լ�
    /// </summary>
    public void ApplyGadget(Gadget gadget)
    {
        //gadgetSlotList
        gadgetSlotList[0].Data = gadget.Data;
        gadgetSlotList[0].ApplyCheck();
    }

}
