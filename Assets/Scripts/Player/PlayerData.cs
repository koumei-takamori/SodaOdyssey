/**********************************************************
 *
 *  PlayerData.cs
 *  �v���C���[�̏��
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField]
    private int m_maxHp; // �ő�HP

    [SerializeField]
    float m_powerSmall, m_powerMedium, m_powerLarge; // �p���[

    // �v���p�e�B�i��Xgetter�����ɂ���j
    public int MaxHP { get { return m_maxHp; } }
    public float SmallPower { get { return m_powerSmall; } }
    public float MediumPower { get { return m_powerMedium; } }
    public float LargePower { get { return m_powerLarge; } }
}
