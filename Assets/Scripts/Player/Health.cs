using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Transform HealthBar;
    public Material[] EmptyMoonMaterials;

    public bool immortal = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
	{
        if (immortal) return;

        if (currentHealth > 0)
		{
            currentHealth--;
            HealthBar.GetChild(currentHealth).gameObject.GetComponent<MeshRenderer>().material = EmptyMoonMaterials[currentHealth];
        }
        if (currentHealth == 0)
		{
            FindObjectOfType<GameManager>().HandleGameOver();
		}
	}
}
