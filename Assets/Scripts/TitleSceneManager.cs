using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    private void Update()
    {
        // ���̈ړ�����
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("PlayScene"); // �V�[��2�Ɉړ�
        }
    }
}
