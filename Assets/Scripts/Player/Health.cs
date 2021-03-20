using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Transform HealthBar;
    public Material[] EmptyMoonMaterials;

    public bool immortal = false;
    Volume volume;
    Vignette vignette;
    

    void Start()
    {
        currentHealth = maxHealth;
        volume = GameObject.FindGameObjectWithTag("PostProcessing").GetComponent<Volume>();

        Vignette tmp;
        if (volume.profile.TryGet<Vignette>(out tmp)){
            vignette = tmp;
            vignette.intensity.value = .05f;
        }
    }

    public void TakeDamage()
	{
        if (immortal) return;

        if (currentHealth > 0)
		{
            currentHealth--;
            HealthBar.GetChild(currentHealth).gameObject.GetComponent<MeshRenderer>().material = EmptyMoonMaterials[currentHealth];

            if (currentHealth == 2)
            {
                vignette.intensity.value = .6f;
            }

            if (currentHealth == 1)
            {
                vignette.intensity.value = .9f;
            }

            if (currentHealth == 0)
            {
                FindObjectOfType<GameManager>().HandleGameOver();
            }
        }
	}
}
