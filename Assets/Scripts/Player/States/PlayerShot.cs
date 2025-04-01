/**********************************************************
 *
 *  PlayerShot.cs
 *  �v���C���[�̔��˃X�e�[�g
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class PlayerShot : IPlayerState
{
    //	�v���C���[
    private Player m_player;

    // ���˗�
    private float m_power;

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
        // �͂�ݒ�
        SetShotPower(m_player.PlayerData.ChargeTime);
        m_player.Shaker.Shot();
    }

    public void Update()
    {
        // �J�[�\���ʒu���擾
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // �}�E�X�̈ʒu����v���C���[�ւ̕����x�N�g��
        Vector3 direction = (m_player.transform.position - mousePos).normalized;

        // �͂�������
        m_player.Rigidbody.AddForce(direction * m_power);

        Debug.Log("State :" + " ����");

        m_player.StateMachine.ChangeState((int)PlayerState.Idle);
    }

    public void OnExit()
    {
    }

    /// <summary>
    /// ���ˎ��̗͂��擾
    /// </summary>
    /// <param name="chargeTime">�`���[�W����</param>
    private void SetShotPower(float chargeTime)
    {
        // Debug.Log("�`���[�W����" + chargeTime);

        if (chargeTime < 1.0f)
        {
            m_power = m_player.PlayerData.SmallPower; // ��
        }
        else if (chargeTime < 3.0f)
        {
            m_power = m_player.PlayerData.MediumPower; // ��
        }
        else
        {
            m_power = m_player.PlayerData.LargePower; // ��
        }
    }
}
