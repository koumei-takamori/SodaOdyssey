/**********************************************************
 *
 *  PlayerStateMachine.cs
 *  �v���C���[�̃X�e�[�g�}�V��
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/
using System.Collections.Generic;
using UnityEngine;

// �X�e�[�genum
public enum PlayerState : int
{
    None = -1,
    Idle = 0,
    Charge = 1,
    Shot = 2
}

public class PlayerStateMachine : MonoBehaviour
{
    // ���݂̃X�e�[�g
    private IPlayerState m_currentState;

    // �X�e�[�gID��ۑ�
    private int m_currentStateID;

    // �S�ẴX�e�[�g��`
    private readonly Dictionary<int, IPlayerState> m_states = new Dictionary<int, IPlayerState>();

    // �v���p�e�B
    public IPlayerState CurrentState => m_currentState;

    // ���݂̃X�e�[�gID���擾����v���p�e�B
    public int CurrentStateID => m_currentStateID;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public PlayerStateMachine(Player player)
    {
        // �X�e�[�g��ǉ�
        m_states.Add((int)PlayerState.Idle, new PlayerIdle(player));
        m_states.Add((int)PlayerState.Charge, new PlayerCharge(player));
        m_states.Add((int)PlayerState.Shot, new PlayerShot(player));
    }

    /// <summary>
    /// ����������
    /// </summary>
    public void Initialize(int stateID)
    {
        m_currentStateID = stateID;
        m_currentState = m_states[stateID];
        m_currentState.OnEnter();
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    public void Update()
    {
        if (m_currentState == null)
            return;

        m_currentState.Update();

        // Shot�X�e�[�g�̃N�[���_�E������������ɍX�V
        if (m_states.TryGetValue((int)PlayerState.Shot, out var shotState))
        {
            if (shotState is PlayerShot playerShot)
            {
                playerShot.CollDown();  
            }
        }
    }

    /// <summary>
    /// �X�e�[�g�̐؂�ւ�
    /// </summary>
    public void ChangeState(int nextStateID)
    {
        m_currentState.OnExit();

        m_currentStateID = nextStateID;  // �X�e�[�gID���X�V
        m_currentState = m_states[nextStateID];

        m_currentState.OnEnter();
    }
}
