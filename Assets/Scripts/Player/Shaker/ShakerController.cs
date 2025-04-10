/**********************************************************
 *
 *  ShakerController.cs
 *  シェイカーの制御
 *
 *  制作者 : ��森 煌明
 *  制作日 : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class ShakerController : MonoBehaviour
{
    // プレイヤー
    public Player m_player;
    // プレイヤーとの距離
    public float m_orbitRadius = 0.3f;
    // 前フレームの位置
    private Vector3 m_previousPosition;
    // シェイクした距離
    private float m_shakeDistance;

    // 弾
    [SerializeField]
    private GameObject m_bulletPrefab;

    //クールタイム
    [SerializeField]
    private static float COOLTIME = 1.0f;

    //タイマー
    private float m_timer;


    // プロパティ
    public float TotalDistance {  get { return m_shakeDistance; } }

    // 実行前初期化処理
    private void Awake()
    {
    }

    /// <summary>
    /// クールダウン(常に更新)
    /// </summary>
    public void CoolDown()
    {
        if (m_timer > 0.0f)
            m_timer -= Time.deltaTime;
    }

    // 更新処理
    private void Update()
    {
        // マウスのスクリーン座標を取得し、ワールド座標に変換
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 2DなのでZ座標は無視

        // プレイヤーを中心とした方向を計算
        Vector3 direction = (mousePosition - m_player.transform.position).normalized;

        // 子オブジェクトの新しい位置を計算
        Vector3 newPosition = m_player.transform.position + direction * m_orbitRadius;

        // マウスを押している間だけ移動距離を計測
        if (Input.GetMouseButton(0)) // 左クリック押下時
        {
            // 初回のみ previousPosition を設定
            if (m_previousPosition == Vector3.zero)
                m_previousPosition = newPosition;

            // 前回の位置と現在の位置の距離を加算
            m_shakeDistance += Vector3.Distance(m_previousPosition, newPosition);
        }

        // 子オブジェクトの位置を更新
        transform.position = newPosition;

        // マウスの方向を向くように回転
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 現在の位置を保存（次のフレームの比較用）
        m_previousPosition = newPosition;
    }

    /// <summary>
    /// 発射処理
    /// </summary>
    /// <returns>発射できたか</returns>
    public bool Shot()
    {
        // クールタイムを消費していたら発射
        if (m_timer <= 0.0f)
        {
            // マウスのスクリーン座標を取得し、ワールド座標に変換
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2DなのでZ座標は無視

            // プレイヤーを中心とした方向を計算
            Vector3 direction = (mousePosition - m_player.transform.position).normalized;
            // マウスの方向を向くように回転
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // 弾を生成
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletController>().SetDirection(direction);

            // リセット
            m_shakeDistance = 0;
            m_previousPosition = Vector3.zero;
            // クールタイム設定
            m_timer = COOLTIME;

            // 発射した
            return true;
        }
      
        // 発射できなかった
        return false;
    }
}
