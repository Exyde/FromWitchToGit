using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPannel;
 
    public Texture2D dialogueCursor;
    public bool showCursor = false;

    private Vector2 hotspot = Vector2.zero;

    private void Start()
    {
        CursorMode mode = CursorMode.ForceSoftware;
        hotspot = new Vector2(0, dialogueCursor.height);

        Cursor.SetCursor(dialogueCursor, hotspot, mode);

        //Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = showCursor;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        print("leaving");
        Application.Quit();
    }
}
