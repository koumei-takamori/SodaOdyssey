using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField]
    private int m_maxHp; // �ő�HP
    [SerializeField]
    float m_powerSmall, m_powerMedium, m_powerLarge; // �p���[


    [Header("�Y�_�`���[�W")]
    [SerializeField]
    private float m_chargeTime;

    // �v���p�e�B�i��Xgetter�����ɂ���j
    public int MaxHP { get { return m_maxHp; } }

    public float ChargeTime { get { return m_chargeTime; } set { m_chargeTime = value; } }
    public float SmallPower { get { return m_powerSmall; } }
    public float MediumPower { get { return m_powerMedium; } }
    public float LargePower { get { return m_powerLarge; } }
}
