using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 弾速
    [SerializeField]
    private float m_speed;

    // 命中時のダメージ
    [SerializeField]
    private int m_damage;

    // 存在時間(秒)この時間が過ぎると消滅
    [SerializeField]
    private float m_limitTime;

    // リジッドボディ
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
        // 移動ベクトルをもとに移動
        transform.position += (Vector3)direction * m_speed * Time.deltaTime;

        // 消滅判定
        m_limitTime -= Time.deltaTime;
        if (m_limitTime < 0.0f)
        {// 存在時間が0になったら消滅
            Destroy(gameObject);
        }
    }

    // トリガー進入時に呼出
	private void OnTriggerEnter2D (Collider2D collision)
	{
		string tag = collision.gameObject.tag;

		// 命中対象ごとの処理
		if (tag == "Enemy")
		{// エネミーに命中
			// ここに命中時の処理
		}
		else if (tag == "Ground")
		{// 地面・壁に命中
			Destroy (gameObject);
		}
	}
}
