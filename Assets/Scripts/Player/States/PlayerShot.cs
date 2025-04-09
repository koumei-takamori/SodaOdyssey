/**********************************************************
 *
 *  PlayerShot.cs
 *  プレイヤーの発射ステート
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/31
 *
 *********************************************************/
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShot : IPlayerState
{
    //	プレイヤー
    private Player m_player;

    // 発射力
    private float m_power;

    // シェイクした距離
    private float m_shakingDistance;


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
        // シェイクした距離を取得
        m_shakingDistance = m_player.Shaker.TotalDistance;
    }

    public void Update()
    {
        // 発射できれば力が加わる
        if(m_player.Shaker.Shot())
        {
            // 発射
            Debug.Log("State :" + " 発射");

            // 力を設定
            SetShotPower();

            // カーソル位置を取得
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // マウスの位置からプレイヤーへの方向ベクトル
            Vector3 direction = (m_player.transform.position - mousePos).normalized;

            // 速度をリセットする
            m_player.Rigidbody.velocity = new Vector3(0, 0, 0);

            // 力を加える
            m_player.Rigidbody.AddForce(direction * m_power);
        }
       
        // 状態の遷移
        m_player.StateMachine.ChangeState((int)PlayerState.Idle);
    }

    public void OnExit()
    {
    }

    /// <summary>
    /// 発射時の力を取得
    /// </summary>
    private void SetShotPower()
    {
        // Debug.Log("チャージ時間" + chargeTime);

        if (m_shakingDistance < 1.0f)
        {
            m_power = m_player.PlayerData.SmallPower; // 弱
        }
        else if (m_shakingDistance < 3.0f)
        {
            m_power = m_player.PlayerData.MediumPower; // 中
        }
        else
        {
            m_power = m_player.PlayerData.LargePower; // 強
        }
    }

    /// <summary>
    /// クールダウン
    /// </summary>
    public void CollDown()
    {
        m_player.Shaker.CoolDown();
    }
}
