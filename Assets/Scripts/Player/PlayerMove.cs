/**********************************************************
 *
 *  PlayerMove.cs
 *  プレイヤーの移動
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    //	コンポーネント
    [SerializeField]
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    private Camera m_mainCam;

    [Header("移動")]
    [SerializeField]
    private float m_moveSpeed;      // 移動速度
    [SerializeField]
    private float m_speedChangeRate;  // 移動速度の変更速度
    [SerializeField]
    private float m_jumpPower;      // ジャンプ力

    //	移動禁止フラグ
    private bool m_cantMove;


    [Header("接地判定")]
    [SerializeField]
    private bool m_drawGizmos;       //	ギズモの描画フラグ
    [SerializeField]
    private Vector3 m_checkAreaSize;    // 判定エリアのサイズ
    [SerializeField]
    private Vector3 m_checkAreaOffset;  // 判定エリアのオフセット
    [SerializeField]
    private LayerMask m_groundLayerMask;    // 地面とするレイヤーのマスク

    // 接地フラグ
    private bool m_isGrounded;

    //	プロパティ
    public bool IsGrounded { get { return m_isGrounded; } }

    // 実行前初期化処理
    private void Awake()
    {
        //	コンポーネントの取得
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // 初期化処理
    private void Start()
    {
    }

    // 更新処理
    private void Update()
    {
        //	接地判定
        GroundCheck();
        //	移動禁止判定
        CheckMovable();

        //	移動禁止時は処理しない
        if (!m_cantMove)
        {
            //	ジャンプ処理
            Jump();
        }
    }

    //	等間隔更新処理
    private void FixedUpdate()
    {
        //	移動禁止時は処理しない
        if (m_cantMove)
            return;

        //	移動処理
        Move();
    }

    // 移動処理
    private void Move()
    {
        // スケール取得
        Vector3 scale = transform.localScale;

        // 仮の移動処理
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // 移動速度ベクトルを現在値から取得
            Vector2 velocity = m_rigidbody.velocity;
            // X方向の速度を入力から決定
            velocity.x = 5.0f;
            m_rigidbody.velocity = velocity;

            scale.x = 0.5f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // 移動速度ベクトルを現在値から取得
            Vector2 velocity = m_rigidbody.velocity;
            // X方向の速度を入力から決定
            velocity.x = -5.0f;
            m_rigidbody.velocity = velocity;

            scale.x = -0.5f;
        }

        transform.localScale = scale;
    }

    // ジャンプ処理
    private void Jump()
    {
        // 接地していなければ処理しない
        if (!m_isGrounded)
            return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpPower);
        }
    }

    // 着地判定
    private void GroundCheck()
    {
        //	地面を判定する
        m_isGrounded = Physics2D.OverlapBox(
            transform.position + m_checkAreaOffset,
            m_checkAreaSize,
            0.0f,
            m_groundLayerMask
            );

        Debug.Log( "接地判定" + m_isGrounded );
    }

    // 移動可能判定
    private void CheckMovable()
    {
    }

#if UNITY_EDITOR
    // デバッグギズモ
    private void OnDrawGizmosSelected()
    {
        if (!m_drawGizmos)
            return;

        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        Gizmos.DrawCube(transform.position + m_checkAreaOffset, m_checkAreaSize);
    }
#endif
}
