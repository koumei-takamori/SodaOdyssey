/**********************************************************
 *
 *  Player.cs
 *  �v���C���[
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{

    // ���W�b�h�{�f�B
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    // �v���C���[�f�[�^
    [SerializeField]
    private PlayerData m_playerData;

    // �ړ�
    private PlayerMove m_move;
    // �X�e�[�g�}�V��
    private PlayerStateMachine m_playerStateMachine;
    // �v���C���[�X�e�\�^�X
    private PlayerStatus m_playerStatus;

    // �v���p�e�B
    public Rigidbody2D Rigidbody { get { return m_rigidBody; } }
    public PlayerData PlayerData { get { return m_playerData; } }
    public PlayerMove PlayerMove { get { return m_move; } }
    public PlayerStateMachine StateMachine { get { return m_playerStateMachine; } }
    public PlayerStatus PlayerStatus { get { return m_playerStatus; } }


    // ���s�O����������
    private void Awake()
    {
        //���W�b�h�{�f�B�̎擾
        m_rigidBody = GetComponent<Rigidbody2D>();
        //	�ړ��̎擾
        m_move = GetComponent<PlayerMove>();

        //	�v���C���[�X�e�[�^�X�̍쐬
        m_playerStatus = new PlayerStatus();

        //	�X�e�[�g�}�V�[���̍쐬
        m_playerStateMachine = new PlayerStateMachine();

        //	�X�e�[�g�}�V�[���̏�����	��������Ԃ͍U��
        m_playerStateMachine.Initialize(m_playerStateMachine.PlayerIdle);
    }

    // ����������
    private void Start()
    {
        
    }

    // �X�V����
    private void Update()
    {
        //	�X�e�[�g�̍X�V
        m_playerStateMachine.Update();

        //	�v���C���[�̃X�e�[�^�X�̍X�V
        m_playerStatus.Update();


        ////	���S����
        //if (m_playerStatus.IsDie)
        //    Destroy(gameObject);
    }
}
