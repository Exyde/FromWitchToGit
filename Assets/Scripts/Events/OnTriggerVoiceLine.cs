using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class OnTriggerVoiceLine : MonoBehaviour
{
	public AudioClip clip;
	bool hasPlayed = false;
	AudioSource source;

	public bool replayable = false;
	public float cooldown = 5f;
	float timer = 0;

	private void Start()
	{
		hasPlayed = false;
		source = GetComponent<AudioSource>();
		//source.clip = clip;
	}

    private void Update()
    {
        if (replayable)
        {
			if (timer > 0 && hasPlayed)
            {
				timer -= Time.deltaTime;
            }

			if (timer <= 0)
            {
				hasPlayed = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !hasPlayed)
		{
			source.Play();
			hasPlayed = true;

			if (!replayable)
            {
				Destroy(this);
            } else
            {
				timer = cooldown;
            }
		}
	}
}
