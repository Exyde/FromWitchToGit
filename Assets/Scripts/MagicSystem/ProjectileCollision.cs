using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

	public Spell spell;
	public bool InstructSpell = false;

	private void OnCollisionEnter(Collision collision)
	{
		Sorcelable entity = null;

		if (collision.gameObject.TryGetComponent<Sorcelable>(out entity))
		{
			entity.TakeDamage(spell);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag != "Spell" && collision.gameObject.tag != "Player")
		{

			Destroy(gameObject);
		}
	}
}
