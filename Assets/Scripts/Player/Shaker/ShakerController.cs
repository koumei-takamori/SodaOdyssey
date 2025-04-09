/**********************************************************
 *
 *  ShakerController.cs
 *  �V�F�C�J�[�̐���
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class ShakerController : MonoBehaviour
{
    // �v���C���[
    public Player m_player;
    // �v���C���[�Ƃ̋���
    public float m_orbitRadius = 0.3f;
    // �O�t���[���̈ʒu
    private Vector3 m_previousPosition;
    // �V�F�C�N��������
    private float m_shakeDistance;

    // �e
    [SerializeField]
    private GameObject m_bulletPrefab;

    //�N�[���^�C��
    [SerializeField]
    private static float COOLTIME = 1.0f;

    //�^�C�}�[
    private float m_timer;


    // �v���p�e�B
    public float TotalDistance {  get { return m_shakeDistance; } }

    // ���s�O����������
    private void Awake()
    {
    }

    /// <summary>
    /// �N�[���_�E��(��ɍX�V)
    /// </summary>
    public void CoolDown()
    {
        if (m_timer > 0.0f)
            m_timer -= Time.deltaTime;
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
            m_shakeDistance += Vector3.Distance(m_previousPosition, newPosition);
        }

        // �q�I�u�W�F�N�g�̈ʒu���X�V
        transform.position = newPosition;

        // �}�E�X�̕����������悤�ɉ�]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // ���݂̈ʒu��ۑ��i���̃t���[���̔�r�p�j
        m_previousPosition = newPosition;
    }

    /// <summary>
    /// ���ˏ���
    /// </summary>
    /// <returns>���˂ł�����</returns>
    public bool Shot()
    {
        // �N�[���^�C��������Ă����甭��
        if (m_timer <= 0.0f)
        {
            // �}�E�X�̃X�N���[�����W���擾���A���[���h���W�ɕϊ�
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2D�Ȃ̂�Z���W�͖���

            // �v���C���[�𒆐S�Ƃ����������v�Z
            Vector3 direction = (mousePosition - m_player.transform.position).normalized;
            // �}�E�X�̕����������悤�ɉ�]
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // �e�𐶐�
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletController>().SetDirection(direction);

            // ���Z�b�g
            m_shakeDistance = 0;
            m_previousPosition = Vector3.zero;
            // �N�[���^�C���ݒ�
            m_timer = COOLTIME;

            // ���˂���
            return true;
        }
      
        // ���˂ł��Ȃ�����
        return false;
    }
}
