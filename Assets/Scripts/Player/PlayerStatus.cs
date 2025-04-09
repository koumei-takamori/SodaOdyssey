/**********************************************************
 *
 *  PlayerStatus.cs
 *  プレイヤーのステータス
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/30
 *
 *********************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : IDamageReceivable
{
    // プレイヤー
    Player m_player;

    // HP
    private int m_hp;

    // 死亡フラグ
    private bool m_isDead = false;

    // プロパティ
    public int HP { get { return m_hp; } }
    public bool IsDead { get { return m_isDead; } }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="player">プレイヤー</param>
    public PlayerStatus(Player player)
    {
        //プレイヤーコントローラーの取得
        m_player = player;

        //値の取得
        m_hp = m_player.PlayerData.MaxHP;
    }

    public void TakeDamage(int damage)
    {
    }

}
