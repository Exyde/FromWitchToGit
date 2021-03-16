using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    GameObject player;
    public MovementDatas moveDatas;

    public GameObject GameOverCanvas;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameOverCanvas.SetActive(false);
    }

	public void HandleGameOver()
	{
        GameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        moveDatas.canMove = moveDatas.canSpell = false;  
    }

    public void HandleBucheronGameOver()
    {
        StartCoroutine(WaitAndGameOver());
    }

    IEnumerator WaitAndGameOver()
    {
        yield return new WaitForSeconds(2.5f);
        HandleGameOver();
    }

    public void ReloadScene()
	{
        print("Reloading scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
