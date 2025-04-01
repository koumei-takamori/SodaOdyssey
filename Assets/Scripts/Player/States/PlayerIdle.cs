/**********************************************************
 *
 *  PlayerIdle.cs
 *  �v���C���[�̑ҋ@�X�e�[�g
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

public class PlayerIdle : IPlayerState
{
    //	�v���C���[
    private Player m_player;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="player">�v���C���[</param>
    public PlayerIdle(Player player)
    {
        m_player = player;
    }

    // �X�e�[�g�ɓ��������̏���
    public void OnEnter()
    {
    }

    // �X�V����
    public void Update()
    {

        Debug.Log("State :" + " �ҋ@");

        // �X�e�[�g��J�ڂ�����
        // �`���[�W����
        if (Input.GetMouseButtonDown(0))
        {
            m_player.StateMachine.ChangeState((int)PlayerState.Charge);
        }
    }

    // �X�e�[�g���o�����̏���
    public void OnExit()
    {
    }

}
