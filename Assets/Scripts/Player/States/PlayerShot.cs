/**********************************************************
 *
 *  PlayerShot.cs
 *  �v���C���[�̔��˃X�e�[�g
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/31
 *
 *********************************************************/
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShot : IPlayerState
{
    //	�v���C���[
    private Player m_player;

    // ���˗�
    private float m_power;

    // �V�F�C�N��������
    private float m_shakingDistance;


    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="player">�v���C���[</param>
    public PlayerShot(Player player)
    {
        m_player = player;
    }

    public void OnEnter()
    {
        // �V�F�C�N�����������擾
        m_shakingDistance = m_player.Shaker.TotalDistance;
    }

    public void Update()
    {
        // ���˂ł���Η͂������
        if(m_player.Shaker.Shot())
        {
            // ����
            Debug.Log("State :" + " ����");

            // �͂�ݒ�
            SetShotPower();

            // �J�[�\���ʒu���擾
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // �}�E�X�̈ʒu����v���C���[�ւ̕����x�N�g��
            Vector3 direction = (m_player.transform.position - mousePos).normalized;

            // ���x�����Z�b�g����
            m_player.Rigidbody.velocity = new Vector3(0, 0, 0);

            // �͂�������
            m_player.Rigidbody.AddForce(direction * m_power);
        }
       
        // ��Ԃ̑J��
        m_player.StateMachine.ChangeState((int)PlayerState.Idle);
    }

    public void OnExit()
    {
    }

    /// <summary>
    /// ���ˎ��̗͂��擾
    /// </summary>
    private void SetShotPower()
    {
        // Debug.Log("�`���[�W����" + chargeTime);

        if (m_shakingDistance < 1.0f)
        {
            m_power = m_player.PlayerData.SmallPower; // ��
        }
        else if (m_shakingDistance < 3.0f)
        {
            m_power = m_player.PlayerData.MediumPower; // ��
        }
        else
        {
            m_power = m_player.PlayerData.LargePower; // ��
        }
    }

    /// <summary>
    /// �N�[���_�E��
    /// </summary>
    public void CollDown()
    {
        m_player.Shaker.CoolDown();
    }
}
