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
        CursorMode mode = CursorMode.ForceSoftware;
        hotspot = new Vector2(0, dialogueCursor.height);

        Cursor.SetCursor(dialogueCursor, hotspot, mode);

        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = showCursor;
    }
}
