 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class FPSController : MonoBehaviour
{
    #region Public Fields

    [Header("Inputs")]
    public KeyCode RunKey = KeyCode.LeftShift;

    [SerializeField]
    private MovementDatas moveDatas;

    [Space]
    public float gravity = 20.0f;

    [Header ("Camera")]
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [Header ("Debug")]
    //[HideInInspector]
    public bool canMove = true;
    public bool showCursor = true;
	#endregion

	#region Private Fields
	CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
	#endregion

	#region Unity Callback
	void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = showCursor;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(RunKey);

        //Compute Speed
        float curSpeedX = canMove ? (isRunning ? moveDatas.runningSpeed : moveDatas.walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? moveDatas.runningSpeed : moveDatas.walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = moveDatas.jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        //If not grounded, apply gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
	#endregion
}

