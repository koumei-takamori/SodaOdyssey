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
        // ���̈ړ�����
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("ClearScene"); // �V�[��2�Ɉړ�
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�S�[��");

        if (other.CompareTag("Player")) // �v���C���[���G�ꂽ��
        {
            SceneManager.LoadScene("ClearScene"); // �V�[��2�Ɉړ�
        }
    }
}
