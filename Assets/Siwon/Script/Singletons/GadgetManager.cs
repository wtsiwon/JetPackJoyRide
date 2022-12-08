using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManager : Singleton<GadgetManager>
{
    [Tooltip("gadgetDatas")]
    public List<GadgetData> gadgetDatas = new List<GadgetData>();

    [Tooltip("�����ϱ� �� ��ư UI")]
    public Sprite selectBtnSprite;
    [Tooltip("������ ��ư UI")]
    public Sprite selectedBtnSprite;
}
