using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light _light;
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _light.intensity -= 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _light.intensity += 0.1f;
        }
    }
}
