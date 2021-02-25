using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Spell : ScriptableObject
{
	//Never instantiaded -- MLF :D
	//Todo : Update with all the design things for our spells.
	 
	public string spellName = "New Spell";
	public Sprite spellSprite;
	public AudioClip spellSound;

	public float Cooldown = 1f;
	public float Damage = 100;

	public ParticleSystem spellVFX;

	public abstract void Initialize(GameObject go);
	public abstract void TriggerSpell();

}
