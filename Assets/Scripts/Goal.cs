using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    private void Update()
    {
        // �f�o�b�O�p
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

