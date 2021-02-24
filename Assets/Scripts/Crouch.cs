using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FPSController))]
public class Crouch : MonoBehaviour
{
    FPSController controller;
    CharacterController cc;
    
    public KeyCode CrounchKey = KeyCode.C;
    public bool crouched = false;

    float startSize;
    public float crounchSize;

    void Start()
    {
        controller = GetComponent<FPSController>();
        cc = GetComponent<CharacterController>();
        startSize = cc.height;
    }

    void Update()
    {
        if (Input.GetKeyDown(CrounchKey))
		{
            crouched = !crouched;
            CheckCrouch();
		}
    }

    void CheckCrouch()
	{
        cc.height = crouched ? startSize / 2 : startSize;
	}

}
