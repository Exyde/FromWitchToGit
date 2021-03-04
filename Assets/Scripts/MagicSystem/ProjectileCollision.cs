using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
	public Spell spell;

	private void OnCollisionEnter(Collision collision)
	{
		Sorcelable entity = null;

		if (collision.gameObject.TryGetComponent<Sorcelable>(out entity))
		{
			entity.TakeDamage(spell);
			InstantiateImpactVFX(spell.ImpactPrefab);
			Destroy(gameObject);
		}

		else if (collision.gameObject.tag != "Spell" && collision.gameObject.tag != "Player")
		{
			InstantiateImpactVFX(spell.ImpactPrefab);
			Destroy(gameObject);
		}
		else return;
	}
	void InstantiateImpactVFX(GameObject prefab)
	{
		Instantiate(prefab, transform.position, Quaternion.identity);
	}

}
