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

    // チャージ時間
    private float m_chargeTime;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="player">プレイヤー</param>
    public PlayerCharge(Player player)
    {
        m_player = player;
        m_chargeTime = 0;
    }


    public void OnEnter()
    {
        m_chargeTime = 0;
    }

    public void Update()
    {
        Debug.Log("State :" + " チャージ");

        // チャージ時間加算
        m_chargeTime += Time.deltaTime;

        // ステートを遷移させる
        // 発射する
        if (Input.GetMouseButtonUp(0))
        {
            m_player.StateMachine.ChangeState((int)PlayerState.Shot);
        }
    }

    public void OnExit()
    {
        // チャージ時間設定
        m_player.PlayerData.ChargeTime = m_chargeTime;
    }

}
