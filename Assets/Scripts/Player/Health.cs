using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
	{
        if (immortal) return;

        currentHealth--;
        HealthBar.GetChild(currentHealth).gameObject.GetComponent<MeshRenderer>().material = EmptyMoonMaterials[currentHealth];


        if (currentHealth == 0)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
