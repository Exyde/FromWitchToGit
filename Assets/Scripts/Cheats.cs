using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{

    // Cheat Class : Remove for build
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
		{
            SceneManager.LoadScene(0);
		}
    }
}
