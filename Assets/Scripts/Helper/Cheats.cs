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
            FindObjectOfType<RandomizeMaterial>().RandomizeSkin();
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

        if (Input.GetKeyDown(KeyCode.O))
        {
            FindObjectOfType<SpellShooter>().UnlockDeconstruct();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            bool _immortal = FindObjectOfType<Health>().immortal;
            FindObjectOfType<Health>().immortal = !_immortal;
        }
    }

    void ToggleMovement()
	{
            moveDatas.canMove = !moveDatas.canMove;
    }
}
