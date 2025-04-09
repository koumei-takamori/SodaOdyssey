using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    private void Update()
    {
        // デバッグ用
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

