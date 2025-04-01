/**********************************************************
 *
 *  PlayerCharge.cs
 *  �v���C���[�̃`���[�W�X�e�[�g
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class PlayerCharge : IPlayerState
{
    //	�v���C���[
    private Player m_player;

    // �`���[�W����
    private float m_chargeTime;
    
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="player">�v���C���[</param>
    public PlayerCharge(Player player)
    {
        m_player = player;
        m_chargeTime = 0;
    }


    public void OnEnter()
    {
        m_chargeTime = 0;
    }

    public void Update()
    {
        Debug.Log("State :" + " �`���[�W");

        // �`���[�W���ԉ��Z
        m_chargeTime += Time.deltaTime;

        // �X�e�[�g��J�ڂ�����
        // ���˂���
        if (Input.GetMouseButtonUp(0))
        {
            m_player.StateMachine.ChangeState((int)PlayerState.Shot);
        }
    }

    public void OnExit()
    {
        // �`���[�W���Ԑݒ�
        m_player.PlayerData.ChargeTime = m_chargeTime;
    }

}
