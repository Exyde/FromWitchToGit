using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepHandler : MonoBehaviour
{
    public AudioClip[] clips;
    public float waitTime = .75f;
    public float waitTimeR = .25f;
    CharacterController cc;
    AudioSource _source;
    public bool Steping = false;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1 && Steping == false && cc.isGrounded
            || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1 && Steping == false && cc.isGrounded)
        {

            Steping = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _source.clip = clips[Random.Range(0, clips.Length)];
                _source.Play();
                Invoke("ChangeStep", waitTimeR);
                print("ouesh");
            }
            else
            {
                _source.clip = clips[Random.Range(0, clips.Length)];
                _source.Play();
                Invoke("ChangeStep", waitTime);
            }
            //Invoke("FootStep", 0);
            Debug.Log("Steped");
        }
    }

    void FootStep()
    {
        Steping = true;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _source.clip = clips[Random.Range(0, clips.Length)];
            _source.Play();
            Invoke("ChangeStep", waitTimeR);
            print("ouesh");
        } else
        {
            _source.clip = clips[Random.Range(0, clips.Length)];
            _source.Play();
            Invoke("ChangeStep", waitTime);
        }
    }

    void ChangeStep()
    {
        Steping = false;
    }
}
