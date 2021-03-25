using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutePoule : MonoBehaviour
{
    AudioSource _source;

    float startVolume;
    bool muted = false;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        startVolume = _source.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!muted)
            {
                muted = true;
                _source.volume = 0;
                return;
            } else if (muted)
            {
                muted = false;
                _source.volume = startVolume;
                return;
            }
        }
    }
}
