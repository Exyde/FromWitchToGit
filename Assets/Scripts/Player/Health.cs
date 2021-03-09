using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Transform HealthBar;

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
        HealthBar.GetChild(currentHealth).gameObject.SetActive(false);


        if (currentHealth == 0)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
