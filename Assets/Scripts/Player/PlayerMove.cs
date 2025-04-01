/**********************************************************
 *
 *  PlayerMove.cs
 *  �v���C���[�̈ړ�
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    //	�R���|�[�l���g
    [SerializeField]
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    private Camera m_mainCam;

    [Header("�ړ�")]
    [SerializeField]
    private float m_moveSpeed;      // �ړ����x
    [SerializeField]
    private float m_speedChangeRate;  // �ړ����x�̕ύX���x
    [SerializeField]
    private float m_jumpPower;      // �W�����v��

    //	�ړ��֎~�t���O
    private bool m_cantMove;


    [Header("�ڒn����")]
    [SerializeField]
    private bool m_drawGizmos;       //	�M�Y���̕`��t���O
    [SerializeField]
    private Vector3 m_checkAreaSize;    // ����G���A�̃T�C�Y
    [SerializeField]
    private Vector3 m_checkAreaOffset;  // ����G���A�̃I�t�Z�b�g
    [SerializeField]
    private LayerMask m_groundLayerMask;    // �n�ʂƂ��郌�C���[�̃}�X�N

    // �ڒn�t���O
    private bool m_isGrounded;

    //	�v���p�e�B
    public bool IsGrounded { get { return m_isGrounded; } }

    // ���s�O����������
    private void Awake()
    {
        //	�R���|�[�l���g�̎擾
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // ����������
    private void Start()
    {
    }

    // �X�V����
    private void Update()
    {
        //	�ڒn����
        GroundCheck();
        //	�ړ��֎~����
        CheckMovable();

        //	�ړ��֎~���͏������Ȃ�
        if (!m_cantMove)
        {
            //	�W�����v����
            Jump();
        }
    }

    //	���Ԋu�X�V����
    private void FixedUpdate()
    {
        //	�ړ��֎~���͏������Ȃ�
        if (m_cantMove)
            return;

        //	�ړ�����
        Move();
    }

    // �ړ�����
    private void Move()
    {
        // �X�P�[���擾
        Vector3 scale = transform.localScale;

        // ���̈ړ�����
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // �ړ����x�x�N�g�������ݒl����擾
            Vector2 velocity = m_rigidbody.velocity;
            // X�����̑��x����͂��猈��
            velocity.x = 5.0f;
            m_rigidbody.velocity = velocity;

            scale.x = 0.5f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // �ړ����x�x�N�g�������ݒl����擾
            Vector2 velocity = m_rigidbody.velocity;
            // X�����̑��x����͂��猈��
            velocity.x = -5.0f;
            m_rigidbody.velocity = velocity;

            scale.x = -0.5f;
        }

        transform.localScale = scale;
    }

    // �W�����v����
    private void Jump()
    {
        // �ڒn���Ă��Ȃ���Ώ������Ȃ�
        if (!m_isGrounded)
            return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpPower);
        }
    }

    // ���n����
    private void GroundCheck()
    {
        //	�n�ʂ𔻒肷��
        m_isGrounded = Physics2D.OverlapBox(
            transform.position + m_checkAreaOffset,
            m_checkAreaSize,
            0.0f,
            m_groundLayerMask
            );

        Debug.Log( "�ڒn����" + m_isGrounded );
    }

    // �ړ��\����
    private void CheckMovable()
    {
    }

#if UNITY_EDITOR
    // �f�o�b�O�M�Y��
    private void OnDrawGizmosSelected()
    {
        if (!m_drawGizmos)
            return;

        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        Gizmos.DrawCube(transform.position + m_checkAreaOffset, m_checkAreaSize);
    }
#endif
}
