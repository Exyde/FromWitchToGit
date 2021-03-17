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
    public GameObject GameWinCanvas;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameOverCanvas.SetActive(false);
        GameWinCanvas.SetActive(false);
    }

	public void HandleGameOver()
	{
        GameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        moveDatas.canMove = moveDatas.canSpell = false;
        player.GetComponent<RandomizeMaterial>().RandomizeSkin();
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

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HandleGameEnd()
    {
        //Fade screen to black, play music, display text.
        //Coroutines
        //Disable loose canvas aswell ?
        GameWinCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        moveDatas.canMove = moveDatas.canSpell = false;
        FindObjectOfType<BossAI>().gameObject.SetActive(false);

    }
}
