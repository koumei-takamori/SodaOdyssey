/**********************************************************
 *
 *  PlayerIdle.cs
 *  プレイヤーの待機ステート
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/30
 *
 *********************************************************/
using UnityEngine;

public class PlayerIdle : IPlayerState
{
    //	プレイヤー
    private Player m_player;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="player">プレイヤー</param>
    public PlayerIdle(Player player)
    {
        m_player = player;
    }

    // ステートに入った時の処理
    public void OnEnter()
    {
    }

    // 更新処理
    public void Update()
    {

        Debug.Log("State :" + " 待機");

        // ステートを遷移させる
        // チャージする
        if (Input.GetMouseButtonDown(0))
        {
            m_player.StateMachine.ChangeState((int)PlayerState.Charge);
        }
    }

    // ステートを出た時の処理
    public void OnExit()
    {
    }

}
