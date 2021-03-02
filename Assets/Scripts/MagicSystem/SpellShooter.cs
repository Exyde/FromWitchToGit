using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    //Spell 1 : Left Hand
    //Spell 2 : Right Hand
    //Spell 3 : Both Hand

    [Header ("Spell Shooter Data")]
    public Camera mainCam;
    public Transform LFirePoint, RFirePoint;
    public MovementDatas moveDatas;
    public float spellMaxDistance = 1000f;
    public Transform SpellHolder;

    private Vector3 target;
    private float timeToFire;
    private bool leftHand;

    [Header("Spells")]
    public Spell DeconstructSpell;
    public Spell InstructSpell;
    public Spell LunarSpell;

	private void Start()
	{
        DeconstructSpell.TimeToFire = InstructSpell.TimeToFire = LunarSpell.TimeToFire = 0;
	}

	void Update()
    {
        if (!moveDatas.canSpell) return;

        if (Input.GetKey(KeyCode.Alpha1)) // && Time.time >= timeToFire
        {
            ShootSpellSO(DeconstructSpell, LFirePoint);
        }
    }

    void ShootSpellSO(Spell spell, Transform firepoint)
	{
        if ((spell.TimeToFire > Time.time))
        {
            Debug.Log("Too early !");
            return;
        }

        //Update for firerate
        spell.TimeToFire = Time.time + spell.Cooldown;

        //Ray
        target = ComputeRay();

        //Instantiate
        GameObject spellProjectile = Instantiate(spell.SpellPrefab, firepoint.position, Quaternion.identity);
        spellProjectile.name = spell.SpellName;
        spellProjectile.transform.parent = SpellHolder;

        //Velocity
        spellProjectile.GetComponent<Rigidbody>().velocity = (target - firepoint.position).normalized * spell.SpellSpeed;

        //Randomize
        if (spell.Randomize)
		{
            float arcRange = spell.RandomizePercent / 100f;
            iTween.PunchPosition(spellProjectile, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(.5f, 2f));
		}
    }

    void CastSpell(Spell spell)
	{

	}

	#region Helper Fonctions

    Vector3 ComputeRay()
	{
        Ray ray = mainCam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        Vector3 targ;

        if (Physics.Raycast(ray, out hit))
        {
            targ = hit.point;
        }
        else
        {
            targ = ray.GetPoint(spellMaxDistance);
        }

        return targ;
    }
	#endregion
}
