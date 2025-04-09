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

    // ���Ƃ����x�̌W��
    private float m_slowFactor = 0.99f; 

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="player">�v���C���[</param>
    public PlayerCharge(Player player)
    {
        m_player = player;
    }


    public void OnEnter()
    {
    }

    public void Update()
    {
        Debug.Log("State :" + " �`���[�W");

        // ���x��x������
        m_player.Rigidbody.velocity *= m_slowFactor;

        // �X�e�[�g��J�ڂ�����
        // ���˂���
        if (Input.GetMouseButtonUp(0))
        {
            m_player.StateMachine.ChangeState((int)PlayerState.Shot);
        }
    }

    public void OnExit()
    {
    }

}
