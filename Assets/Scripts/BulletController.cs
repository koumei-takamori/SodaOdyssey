using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // �e��
    [SerializeField]
    private float m_speed;

    // �������̃_���[�W
    [SerializeField]
    private int m_damage;

    // ���ݎ���(�b)���̎��Ԃ��߂���Ə���
    [SerializeField]
    private float m_limitTime;

    // ���W�b�h�{�f�B
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    private Vector2 direction;


    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    // Update
    void Update()
    {
        // �ړ��x�N�g�������ƂɈړ�
        transform.position += (Vector3)direction * m_speed * Time.deltaTime;

        // ���Ŕ���
        m_limitTime -= Time.deltaTime;
        if (m_limitTime < 0.0f)
        {// ���ݎ��Ԃ�0�ɂȂ��������
            Destroy(gameObject);
        }
    }

    // �g���K�[�i�����Ɍďo
	private void OnTriggerEnter2D (Collider2D collision)
	{
		string tag = collision.gameObject.tag;

		// �����Ώۂ��Ƃ̏���
		if (tag == "Enemy")
		{// �G�l�~�[�ɖ���
			// �����ɖ������̏���
		}
		else if (tag == "Ground")
		{// �n�ʁE�ǂɖ���
			Destroy (gameObject);
		}
	}
}
