/**********************************************************
 *
 *  PlayerStatus.cs
 *  �v���C���[�̃X�e�[�^�X
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : IDamageReceivable
{
    // �v���C���[
    Player m_player;

    // HP
    private int m_hp;

    // ���S�t���O
    private bool m_isDead = false;

    // �v���p�e�B
    public int HP { get { return m_hp; } }
    public bool IsDead { get { return m_isDead; } }

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="player">�v���C���[</param>
    public PlayerStatus(Player player)
    {
        //�v���C���[�R���g���[���[�̎擾
        m_player = player;

        //�l�̎擾
        m_hp = m_player.PlayerData.MaxHP;
    }

    public void TakeDamage(int damage)
    {
    }

}
