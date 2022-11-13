using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeManager : MonoBehaviour
{
    private void Awake()
    {
        SetResolution(); // �ʱ⿡ ���� �ػ� ����
        GL.Clear(true, true, Color.black);
    }

    void OnPreCull() => GL.Clear(true, true, Color.black);
    /* �ػ� �����ϴ� �Լ� */
    public void SetResolution()
    {
        int setWidth = 2960; // ����� ���� �ʺ�
        int setHeight = 1440; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, setHeight, true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
        GL.Clear(true, true, Color.black);
    }
}