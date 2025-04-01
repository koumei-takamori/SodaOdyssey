using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Goal : MonoBehaviour
{

    private void Update()
    {
        // 仮の移動処理
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("ClearScene"); // シーン2に移動
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");

        if (other.CompareTag("Player")) // プレイヤーが触れたら
        {
            SceneManager.LoadScene("ClearScene"); // シーン2に移動
        }
    }
}
