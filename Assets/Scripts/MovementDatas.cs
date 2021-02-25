using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Datas/Movement Datas")]
public class MovementDatas : ScriptableObject
{
    [Header("Speeds")]
    [Range(1, 10)]
    public float walkingSpeed = 7.5f;
    [Range(1, 20)]
    public float runningSpeed = 11.5f;
    [Range(1, 20)]
    public float jumpSpeed = 8.0f;
    [Range(1, 10)]
    public float crouchSpeed = 8.0f;
}
