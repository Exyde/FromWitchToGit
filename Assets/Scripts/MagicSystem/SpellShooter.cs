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
    public Transform SpellHolder;
    public MovementDatas moveDatas;
    public float spellMaxDistance = 1000f;
    AnimationController animationController;
    //public Transform SpellHolder;

    private Vector3 target;
    private float timeToFire;
    private bool leftHand;
    private float globalCooldown = .5f;
    private float globalTimeToSpell = 0f;


    [Header("Spells")]
    public Spell DeconstructSpell;
    public Spell InstructSpell;
    public Spell LunarSpell;

    [Header("Spell Feedback")]
    public GameObject DeconstructReadyFeedback;
    public GameObject InstructReadyFeedback;
    public GameObject InstructSpellUI;
    public GameObject DeconstructSpellUI;

    public Material InstructCoolDownMaterial;
    public Material InstructReadyMaterial;
    public Material DeconstructCoolDownMaterial;
    public Material DeconstructReadyMaterial;

    bool deconstructReady;
    bool instructReady;


    private void Start()
	{
        animationController = GetComponent<AnimationController>();
        DeconstructSpell.TimeToFire = InstructSpell.TimeToFire = LunarSpell.TimeToFire = 0;
        globalTimeToSpell = 0;
	}

	void Update()
    {
        if (!moveDatas.canSpell) return;

        if (DeconstructSpell.TimeToFire <= Time.time && !deconstructReady)
		{
            DeconstructReadyFeedback.GetComponent<ParticleSystem>().Play();
            DeconstructSpellUI.GetComponent<MeshRenderer>().material = DeconstructReadyMaterial;
            deconstructReady = true;
		}

        if (InstructSpell.TimeToFire <= Time.time && !instructReady)
        {
            InstructReadyFeedback.GetComponent<ParticleSystem>().Play();
            InstructSpellUI.GetComponent<MeshRenderer>().material = InstructReadyMaterial;

            instructReady = true;
        }


        if (Input.GetKey(KeyCode.Alpha1) && globalTimeToSpell < Time.time)
        {
            ShootSpellSO(DeconstructSpell, LFirePoint);
        }

        if (Input.GetKey(KeyCode.Alpha2) && globalTimeToSpell < Time.time)
        {
            ShootSpellSO(InstructSpell, RFirePoint);
        }

        if (Input.GetKey(KeyCode.Alpha3) && globalTimeToSpell < Time.time)
        {
            //ShootSpellSO(DeconstructSpell, LFirePoint);
        }
    }

    void ShootSpellSO(Spell spell, Transform firepoint)
	{
        if ((spell.TimeToFire > Time.time))
        {
            return;
        }

        if (firepoint == LFirePoint)
		{
            animationController.SetLeftSpell();
            deconstructReady = false;
            DeconstructSpellUI.GetComponent<MeshRenderer>().material = DeconstructCoolDownMaterial;
        }
        else
		{
            animationController.SetRightSpell();
            instructReady = false;
            InstructSpellUI.GetComponent<MeshRenderer>().material = InstructCoolDownMaterial;
        }

        //Update global timer
        globalTimeToSpell = Time.time + globalCooldown;

        //Update for firerate
        spell.TimeToFire = Time.time + spell.Cooldown;

        //Ray
        target = ComputeTargetRay();

        //Instantiate
        GameObject spellProjectile = Instantiate(spell.SpellPrefab, firepoint.position, spell.SpellPrefab.transform.rotation);
        spellProjectile.name = spell.SpellName;
        //spellProjectile.transform.parent = SpellHolder;

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
        //Todo : Implement Lunar Shield Spell
	}

	#region Helper Fonctions

    Vector3 ComputeTargetRay()
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(LFirePoint.transform.position, .1f);
        Gizmos.DrawWireSphere(RFirePoint.transform.position, .1f);
    }
}
