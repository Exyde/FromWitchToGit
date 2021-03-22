using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucheronGameOver : MonoBehaviour
{
    DialogueManager dm;
    GameManager gm;
    bool triggered = false;

    void Start()
    {
        dm = GetComponent<DialogueManager>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (dm.auraAmount == 0 && !triggered)
        {
            triggered = true;
            gm.HandleBucheronGameOver();
            //Destroy(this.GetComponent<AudioSource>());
        } 
    }
}
