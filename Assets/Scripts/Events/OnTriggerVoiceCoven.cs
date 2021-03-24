using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerVoiceCoven : MonoBehaviour
{
	public AudioClip clip;
	bool hasPlayed = false;
	AudioSource source;

	public GameObject CovenVFX;
	public GameObject TextCanvas;

	private void Start()
	{
		hasPlayed = false;
		source = GetComponent<AudioSource>();
		source.clip = clip;
		TextCanvas.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !hasPlayed)
		{
			source.Play();
			hasPlayed = true;
			CovenVFX.SetActive(true);
			TextCanvas.SetActive(true);

			StartCoroutine(DisableFX());

		}
	}

	IEnumerator DisableFX()
    {
		yield return new WaitForSeconds(clip.length);
		CovenVFX.SetActive(false);
		TextCanvas.SetActive(false);

	}
}
