using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    private void Update()
    {
        // 仮の移動処理
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("PlayScene"); // シーン2に移動
        }
    }
}
