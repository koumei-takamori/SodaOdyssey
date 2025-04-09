/**********************************************************
 *
 *  PlayerCharge.cs
 *  プレイヤーのチャージステート
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class PlayerCharge : IPlayerState
{
    //	プレイヤー
    private Player m_player;

    // 落とす速度の係数
    private float m_slowFactor = 0.99f; 

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="player">プレイヤー</param>
    public PlayerCharge(Player player)
    {
        m_player = player;
    }


    public void OnEnter()
    {
    }

    public void Update()
    {
        Debug.Log("State :" + " チャージ");

        // 速度を遅くする
        m_player.Rigidbody.velocity *= m_slowFactor;

        // ステートを遷移させる
        // 発射する
        if (Input.GetMouseButtonUp(0))
        {
            m_player.StateMachine.ChangeState((int)PlayerState.Shot);
        }
    }

    public void OnExit()
    {
    }

}
