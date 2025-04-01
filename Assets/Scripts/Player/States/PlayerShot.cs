/**********************************************************
 *
 *  PlayerShot.cs
 *  プレイヤーの発射ステート
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class PlayerShot : IPlayerState
{
    //	プレイヤー
    private Player m_player;

    // 発射力
    private float m_power;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="player">プレイヤー</param>
    public PlayerShot(Player player)
    {
        m_player = player;
    }

    public void OnEnter()
    {       
        // 力を設定
        SetShotPower(m_player.PlayerData.ChargeTime);
        m_player.Shaker.Shot();
    }

    public void Update()
    {
        // カーソル位置を取得
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // マウスの位置からプレイヤーへの方向ベクトル
        Vector3 direction = (m_player.transform.position - mousePos).normalized;

        // 力を加える
        m_player.Rigidbody.AddForce(direction * m_power);

        Debug.Log("State :" + " 発射");

        m_player.StateMachine.ChangeState((int)PlayerState.Idle);
    }

    public void OnExit()
    {
    }

    /// <summary>
    /// 発射時の力を取得
    /// </summary>
    /// <param name="chargeTime">チャージ時間</param>
    private void SetShotPower(float chargeTime)
    {
        // Debug.Log("チャージ時間" + chargeTime);

        if (chargeTime < 1.0f)
        {
            m_power = m_player.PlayerData.SmallPower; // 弱
        }
        else if (chargeTime < 3.0f)
        {
            m_power = m_player.PlayerData.MediumPower; // 中
        }
        else
        {
            m_power = m_player.PlayerData.LargePower; // 強
        }
    }
}
