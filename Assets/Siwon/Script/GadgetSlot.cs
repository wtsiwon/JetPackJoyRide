using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GadgetSlot : MonoBehaviour
{
    private GadgetData data;
    public GadgetData Data
    {
        get
        {
            return data;
        } 
        set
        {
            data = value;
            if (data == null)
            {
                gadgetIcon = null;
            }
            ApplyIcon();
        }
    }

    private void OnEnable()
    {
        
    }

    [Header("GadgetSlot UI")]
    [Space(15f)]
    [SerializeField]
    [Tooltip("���� ��ư")]
    private Button putOnbtn;

    [SerializeField]
    [Tooltip("���� ������")]
    private Image gadgetIcon;

    public void ApplyIcon()
    {
        gadgetIcon.sprite = data.icon;
    }

    private void SetSlot()
    {
        if(Data == null)
        {
            gadgetIcon = null;
        }
    }

}
