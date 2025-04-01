using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField]
    private int m_maxHp; // 最大HP
    [SerializeField]
    float m_powerSmall, m_powerMedium, m_powerLarge; // パワー


    [Header("炭酸チャージ")]
    [SerializeField]
    private float m_chargeTime;

    // プロパティ（後々getterだけにする）
    public int MaxHP { get { return m_maxHp; } }

    public float ChargeTime { get { return m_chargeTime; } set { m_chargeTime = value; } }
    public float SmallPower { get { return m_powerSmall; } }
    public float MediumPower { get { return m_powerMedium; } }
    public float LargePower { get { return m_powerLarge; } }
}
