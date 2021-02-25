using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FPSController))]
public class Crouch : MonoBehaviour
{
	#region Fields
    //Private Fields
    FPSController controller;
    CharacterController cc;

	//Public Fields
	public KeyCode CrounchKey = KeyCode.C;
    public bool crouched = false;
    [SerializeField]
    MovementDatas moveDatas;

    //Size Datas
    //public float crounchSize;
    float startSize;

    float startWalkSpeed;
    float startRunSpeed;
    float crouchSpeed;
	#endregion

	#region Unity CallBacks
	void Start()
    {
        controller = GetComponent<FPSController>();
        cc = GetComponent<CharacterController>();
        startSize = cc.height;

        startWalkSpeed = moveDatas.walkingSpeed;
        startRunSpeed = moveDatas.runningSpeed;
        crouchSpeed = moveDatas.crouchSpeed;
    }

    void Update()
    {
        if (Input.GetKey(CrounchKey))
		{
            moveDatas.walkingSpeed = crouchSpeed;
            moveDatas.runningSpeed = crouchSpeed;
            cc.height = startSize / 2;
		}

        if (Input.GetKeyUp(CrounchKey))
		{
            moveDatas.walkingSpeed = startWalkSpeed;
            moveDatas.runningSpeed = startRunSpeed;
            cc.height = startSize;
        }
    }
	#endregion

	void CheckCrouch()
	{
        cc.height = crouched ? startSize / 2 : startSize;
	}
}
