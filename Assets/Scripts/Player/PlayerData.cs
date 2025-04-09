/**********************************************************
 *
 *  PlayerData.cs
 *  プレイヤーの情報
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField]
    private int m_maxHp; // 最大HP

    [SerializeField]
    float m_powerSmall, m_powerMedium, m_powerLarge; // パワー

    // プロパティ（後々getterだけにする）
    public int MaxHP { get { return m_maxHp; } }
    public float SmallPower { get { return m_powerSmall; } }
    public float MediumPower { get { return m_powerMedium; } }
    public float LargePower { get { return m_powerLarge; } }
}
