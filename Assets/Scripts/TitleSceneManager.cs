using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    private void Update()
    {
        // ‰¼‚ÌˆÚ“®ˆ—
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("PlayScene"); // ƒV[ƒ“2‚ÉˆÚ“®
        }
    }
}
