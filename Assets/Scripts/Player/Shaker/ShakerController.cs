/**********************************************************
 *
 *  ShakerController.cs
 *  �V�F�C�J�[�̐���
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/31
 *
 *********************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerController : MonoBehaviour
{
    // �v���C���[
    public Player m_player;
    // �v���C���[�Ƃ̋���
    public float m_orbitRadius = 0.3f;
    // �O�t���[���̈ʒu
    private Vector3 m_previousPosition;
    // ���ړ�����
    private float m_totalDistance;

    // �e
    [SerializeField]
    private GameObject m_bulletPrefab;


    // �v���p�e�B
    public float TotalDistance {  get { return m_totalDistance; } }

    // ���s�O����������
    private void Awake()
    {
    }

    // �X�V����
    private void Update()
    {
        // �}�E�X�̃X�N���[�����W���擾���A���[���h���W�ɕϊ�
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 2D�Ȃ̂�Z���W�͖���

        // �v���C���[�𒆐S�Ƃ����������v�Z
        Vector3 direction = (mousePosition - m_player.transform.position).normalized;

        // �q�I�u�W�F�N�g�̐V�����ʒu���v�Z
        Vector3 newPosition = m_player.transform.position + direction * m_orbitRadius;

        // �}�E�X�������Ă���Ԃ����ړ��������v��
        if (Input.GetMouseButton(0)) // ���N���b�N������
        {
            // ����̂� previousPosition ��ݒ�
            if (m_previousPosition == Vector3.zero)
                m_previousPosition = newPosition;

            // �O��̈ʒu�ƌ��݂̈ʒu�̋��������Z
            m_totalDistance += Vector3.Distance(m_previousPosition, newPosition);
        }
        else
        {
            // �}�E�X�𗣂����烊�Z�b�g
            m_totalDistance = 0;
            m_previousPosition = Vector3.zero;
        }

        // �q�I�u�W�F�N�g�̈ʒu���X�V
        transform.position = newPosition;

        // �}�E�X�̕����������悤�ɉ�]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // ���݂̈ʒu��ۑ��i���̃t���[���̔�r�p�j
        m_previousPosition = newPosition;

        // �f�o�b�O�p�Ɉړ�������\��
        // Debug.Log("���ړ�����: " + m_totalDistance);
    }

    // ����
    public void Shot()
    {
        // �}�E�X�̃X�N���[�����W���擾���A���[���h���W�ɕϊ�
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 2D�Ȃ̂�Z���W�͖���

        // �v���C���[�𒆐S�Ƃ����������v�Z
        Vector3 direction = (mousePosition - m_player.transform.position).normalized;
        // �}�E�X�̕����������悤�ɉ�]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetDirection(direction);
    }
}
