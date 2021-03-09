using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
	public GameObject ImpactPrefab;

	private void OnCollisionEnter(Collision collision)
	{
		Health playerHeatlh = null;

		if (collision.gameObject.TryGetComponent<Health>(out playerHeatlh))
		{
			playerHeatlh.TakeDamage();
			InstantiateImpactVFX(ImpactPrefab);
			Destroy(gameObject);
		}

		else if (collision.gameObject.tag != "Player")
		{
			InstantiateImpactVFX(ImpactPrefab);
			Destroy(gameObject);
		}
		else return;
	}
	void InstantiateImpactVFX(GameObject prefab)
	{
		Instantiate(prefab, transform.position, Quaternion.identity);
	}

}
