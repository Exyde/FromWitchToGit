using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed), Space.Self);
    }
}
