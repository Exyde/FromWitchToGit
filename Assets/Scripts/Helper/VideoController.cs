using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoController : MonoBehaviour
{
    public float startDelay = 1.5f;
    bool playing = false;

    public float timer;
    public VideoPlayer Player;

    private void Start()
    {
        timer = (float)Player.clip.length;
        Cursor.visible = false;
    }

    void Update()
    {
        startDelay -= Time.deltaTime;
        //GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.white, startDelay);

        if (startDelay <= 0 && !playing)
        {
            Player.Play();
            playing = true;
        }

        if (playing) timer -= Time.deltaTime;

        if (timer <= 0 && playing)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        HandleInputs();
    }

    public void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}