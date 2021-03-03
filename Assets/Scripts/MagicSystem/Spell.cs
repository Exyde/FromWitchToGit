using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Spell", menuName = "Spells")]
public class Spell : ScriptableObject
{
	//Size handled by the prefab.
	//Spell type depending on Collider
	public string SpellName = "New Spell";
	public bool Instruct = false;
	public bool Deconstruct = false;

	public Sprite SpellSprite;

	[Header("Spell Datas")]
	public float Cooldown = 1f;
	public int Charges = 50;
	public float SpellSpeed = 25f;

	[Header ("Debug")]
	//[HideInInspector]
	public float TimeToFire;

	[Header ("Randomize")]
	public bool Randomize = false;
	[Range (0, 100)]
	public int RandomizePercent = 0;

	[Header("Prefabs")]
	public GameObject SpellPrefab; //Projectile
	public GameObject ImpactPrefab;
	public GameObject MuzzlePrefab;

	[Header ("Audio")]
	public AudioClip SpellSound;
	public AudioClip ImpactSound;
	public AudioClip Voiceline;

}
