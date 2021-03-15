using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    public Transform Entity;

    public MovementDatas moveDatas;
    // Cheat Class : Remove for build
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = Entity.position + new Vector3(.5f, .5f ,.5f);
        }

        if (Input.GetKeyDown(KeyCode.Y))
		{
            ToggleMovement();
		}

        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.visible = !Cursor.visible;
        }
    }

    void ToggleMovement()
	{
            moveDatas.canMove = !moveDatas.canMove;
    }
}
