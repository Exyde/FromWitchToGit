using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpell : MonoBehaviour
{
	public GameObject impactVFX;

	bool collided = false;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Spell" && collision.gameObject.tag != "Player" && !collided)
		{
			collided = true;

			var impact = Instantiate(impactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;

			Destroy(impact, .25f);
			Destroy(gameObject);
		}
	}
}
