using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;

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
        currentHealth--;

        if (currentHealth == 0)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
