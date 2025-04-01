/**********************************************************
 *
 *  CameraController.cs
 *  カメラ制御
 *
 *  制作者 : 髙森 煌明
 *  制作日 : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_targetPos;

    // 初期化処理
    void Start()
    {
        
    }

    // 更新処理
    void Update()
    {
        
    }

    //	等間隔更新処理
    private void FixedUpdate()
    {
        Vector3 target = m_targetPos.position;
        target.z = -30.0f;
        transform.position = target;
    }
}
