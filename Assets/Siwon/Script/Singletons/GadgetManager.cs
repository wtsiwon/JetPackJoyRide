using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManager : Singleton<GadgetManager>
{
    [Tooltip("gadgetDatas")]
    public List<Gadget> gadgetDataList = new List<Gadget>();

    [Tooltip("Slot(2ĭ)")]
    public List<GadgetSlot> gedgetSlotList = new List<GadgetSlot>();

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
    }
}
