/**********************************************************
 *
 *  Player.cs
 *  プレイヤー
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    // リジッドボディ
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    // プレイヤーデータ
    [SerializeField]
    private PlayerData m_playerData;

    // シェイカー
    [SerializeField]
    private ShakerController m_shaker;

    // 移動
    private PlayerMove m_move;
    // ステートマシン
    private PlayerStateMachine m_playerStateMachine;
    // プレイヤーステ―タス
    private PlayerStatus m_playerStatus;


    // プロパティ
    public Rigidbody2D Rigidbody { get { return m_rigidBody; } }
    public PlayerData PlayerData { get { return m_playerData; } }
    public PlayerMove PlayerMove { get { return m_move; } }
    public PlayerStateMachine StateMachine { get { return m_playerStateMachine; } }
    public PlayerStatus PlayerStatus { get { return m_playerStatus; } }
    public ShakerController Shaker { get { return m_shaker; } }

    // 実行前初期化処理
    private void Awake()
    {
        //リジッドボディの取得
        m_rigidBody = GetComponent<Rigidbody2D>();
        //	移動の取得
        m_move = GetComponent<PlayerMove>();


        //	プレイヤーステータスの作成
        m_playerStatus = new PlayerStatus(this);
        //	ステートマシーンの作成
        m_playerStateMachine = new PlayerStateMachine(this);
        //	ステートマシーンの初期化
        m_playerStateMachine.Initialize((int)PlayerState.Idle);
    }

    // 初期化処理
    private void Start()
    {
        
    }

    // 更新処理
    private void Update()
    {
        //	ステートの更新
        m_playerStateMachine.Update();

        //	プレイヤーのステータスの更新
        // m_playerStatus.Update();

        //	死亡処理
        if (m_playerStatus.IsDead)
            Destroy(gameObject);
    }
}
