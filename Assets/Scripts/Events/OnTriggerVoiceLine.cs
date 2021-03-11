using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class OnTriggerVoiceLine : MonoBehaviour
{
	public AudioClip clip;
	bool hasPlayed = false;
	AudioSource source;

	private void Start()
	{
		hasPlayed = false;
		source = GetComponent<AudioSource>();
		source.clip = clip;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !hasPlayed)
		{
			//AudioSource.Play(clip);
			source.Play();
			hasPlayed = true;
		}
	}
}
