/**********************************************************
 *
 *  CameraController.cs
 *  �J��������
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/31
 *
 *********************************************************/
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_targetPos;

    // ����������
    void Start()
    {
        
    }

    // �X�V����
    void Update()
    {
        
    }

    //	���Ԋu�X�V����
    private void FixedUpdate()
    {
        Vector3 target = m_targetPos.position;
        target.z = -30.0f;
        transform.position = target;
    }
}
