/**********************************************************
 *
 *  PlayerStateMachine.cs
 *  �v���C���[�̃X�e�[�g�}�V��
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    //	�e�X�e�[�g
    private PlayerIdle m_playerIdle;        //	�ҋ@�X�e�[�g
    private PlayerShot m_playerShot;        //	���˃X�e�[�g

    //	���݂̃X�e�[�g
    private IPlayerState m_currentState;

    //	�e�X�e�[�g�̃v���p�e�B
    public PlayerIdle PlayerIdle { get { return m_playerIdle; } }
    public PlayerShot PlayerShot { get { return m_playerShot; } }

    public IPlayerState CurrentState { get { return m_currentState; } }

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public PlayerStateMachine()
    {
        m_playerIdle = new PlayerIdle();
    }

    /// <summary>
    /// ����������
    /// </summary>
    /// <param name="startState">�ŏ��̃X�e�[�g</param>
    public void Initialize(IPlayerState startState)
    {
        //	�J�n���̃X�e�[�g��ݒ�
        m_currentState = startState;
        //	���ꏈ�����s��
        m_currentState.OnEnter();
    }


    /// <summary>
    /// �X�V����
    /// </summary>
    public void Update()
    {
        //	�X�e�[�g�����ݒ�̂Ƃ��͏������Ȃ�
        if (m_currentState == null)
            return;

        //	���݂̃X�e�[�g���X�V
        m_currentState.Update();
    }

    /// <summary>
    /// �X�e�[�g�̐؂�ւ�
    /// </summary>
    /// <param name="nextState">���̃X�e�[�g</param>
    public void ChangeState(IPlayerState nextState)
    {
        //	�X�e�[�g�̑ޏꏈ�����s��
        m_currentState.OnExit();

        //	�X�e�[�g������������
        m_currentState = nextState;

        //	�X�e�[�g�̓��ꏈ�����s��
        m_currentState.OnEnter();
    }
}
