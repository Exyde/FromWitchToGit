using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{

    public GameObject lg;
    // Cheat Class : Remove for build
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
		{
            SceneManager.LoadScene(0);
		}

        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = lg.transform.position + new Vector3(2, 2, 2);
        }
    }
}