/**********************************************************
 *
 *  PlayerStateMachine.cs
 *  プレイヤーのステートマシン
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/30
 *
 *********************************************************/
using System.Collections.Generic;
using UnityEngine;

// ステートenum
public enum PlayerState : int
{
    None = -1,
    Idle = 0,
    Charge = 1,
    Shot = 2
}

public class PlayerStateMachine : MonoBehaviour
{
    // 現在のステート
    private IPlayerState m_currentState;

    // ステートIDを保存
    private int m_currentStateID;

    // 全てのステート定義
    private readonly Dictionary<int, IPlayerState> m_states = new Dictionary<int, IPlayerState>();

    // プロパティ
    public IPlayerState CurrentState => m_currentState;

    // 現在のステートIDを取得するプロパティ
    public int CurrentStateID => m_currentStateID;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public PlayerStateMachine(Player player)
    {
        // ステートを追加
        m_states.Add((int)PlayerState.Idle, new PlayerIdle(player));
        m_states.Add((int)PlayerState.Charge, new PlayerCharge(player));
        m_states.Add((int)PlayerState.Shot, new PlayerShot(player));
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Initialize(int stateID)
    {
        m_currentStateID = stateID;
        m_currentState = m_states[stateID];
        m_currentState.OnEnter();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public void Update()
    {
        if (m_currentState == null)
            return;

        m_currentState.Update();

        // Shotステートのクールダウン処理だけ常に更新
        if (m_states.TryGetValue((int)PlayerState.Shot, out var shotState))
        {
            if (shotState is PlayerShot playerShot)
            {
                playerShot.CollDown();  
            }
        }
    }

    /// <summary>
    /// ステートの切り替え
    /// </summary>
    public void ChangeState(int nextStateID)
    {
        m_currentState.OnExit();

        m_currentStateID = nextStateID;  // ステートIDを更新
        m_currentState = m_states[nextStateID];

        m_currentState.OnEnter();
    }
}
