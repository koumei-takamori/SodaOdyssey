/**********************************************************
 *
 *  PlayerStateMachine.cs
 *  プレイヤーのステートマシン
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    //	各ステート
    private PlayerIdle m_playerIdle;        //	待機ステート
    private PlayerShot m_playerShot;        //	発射ステート

    //	現在のステート
    private IPlayerState m_currentState;

    //	各ステートのプロパティ
    public PlayerIdle PlayerIdle { get { return m_playerIdle; } }
    public PlayerShot PlayerShot { get { return m_playerShot; } }

    public IPlayerState CurrentState { get { return m_currentState; } }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public PlayerStateMachine()
    {
        m_playerIdle = new PlayerIdle();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="startState">最初のステート</param>
    public void Initialize(IPlayerState startState)
    {
        //	開始時のステートを設定
        m_currentState = startState;
        //	入場処理を行う
        m_currentState.OnEnter();
    }


    /// <summary>
    /// 更新処理
    /// </summary>
    public void Update()
    {
        //	ステートが未設定のときは処理しない
        if (m_currentState == null)
            return;

        //	現在のステートを更新
        m_currentState.Update();
    }

    /// <summary>
    /// ステートの切り替え
    /// </summary>
    /// <param name="nextState">次のステート</param>
    public void ChangeState(IPlayerState nextState)
    {
        //	ステートの退場処理を行う
        m_currentState.OnExit();

        //	ステートを書き換える
        m_currentState = nextState;

        //	ステートの入場処理を行う
        m_currentState.OnEnter();
    }
}
