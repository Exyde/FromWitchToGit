using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public Texture2D dialogueCursor;
    public bool showCursor = false;

    private Vector2 hotspot = Vector2.zero;

    void Start()
    {

        Cursor.SetCursor(dialogueCursor, hotspot, CursorMode.Auto);

        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = showCursor;
    }
}
