using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ǯ���� Types
/// </summary>
public enum EPoolType
{
    BackGround,
    Coin,
    Item,
    Obstacle,
    Rocket,
    Press,
    Effect,
    Sound,

}

public enum EGadgetType
{
    GravityBelt,

}

/// <summary>
/// Ż��
/// </summary>
public enum EVehicleType
{
    None,//�ƹ��͵� �ƴ�
    BusterMachine,//�����͸ӽ�
    Frog,//������
    Wyvern,//���̹�
    GravitySuit,//�߷¼�Ʈ
    ProfitUFO,
}

public enum ETheme//�׸�
{
    Supply,//����
    Process,//����
    Produce,//����
    Package,//������
    Shipping,//�����
    End,
}

/// <summary>
/// �����۵�
/// </summary>
public enum EItemType
{
    Transformation, //����
    Magnet,         //�ڼ�
    Piggybank,      //������
    Booster,        //�ν���
    Coinconverter,  //���κ�ȯ��
    Sizecontrol,    //ũ������
}

/// <summary>
/// ��ֹ� Ÿ��
/// </summary>
public enum EObstacleType
{
    Basic,
    Swing,
    Spin,
    End,
}

/// <summary>
/// �������ϵ�
/// </summary>
public enum ECoinPatternType
{
    CoinPattern1,
    CoinPattern2,
    CoinPattern3,
    CoinPattern4,
    CoinPattern5,
}

public enum EEffectType
{

}

public enum ESoundType
{

}

public enum EDir
{
    Up = 0,
    Down = 180,
    Left = 90,
    Right = 270,
    End = 5,
}


public class Defines : MonoBehaviour
{
    
}
