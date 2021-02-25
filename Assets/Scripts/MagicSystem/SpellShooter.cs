using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    //Todo : Refacto
    public GameObject spell;
    public Transform LFirePoint, RFirePoint;
    public Camera mainCam;
    public float projectileSpeed = 10f;
    public float fireRate = 4f;
    public float arcRange = 1f;

    public float spellMaxDistance = 1000f;

    private Vector3 target;
    private bool leftHand;
    private float timeToFire;

    void Update()
    {
        //Spell 1
        if (Input.GetKey(KeyCode.Alpha1) && Time.time >= timeToFire)
		{
            //For later ShootSpell(Spell spell)

            if (leftHand)
			{
                leftHand = false;
                ShootSpell(spell, LFirePoint);
            } else
			{
                leftHand = true;
                ShootSpell(spell, RFirePoint);
            } 
        }
    }

    void ShootSpell(GameObject spell, Transform firepoint)
	{
        timeToFire = Time.time + 1 / fireRate;
        //Ray Part
        Ray ray = mainCam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
		{
            target = hit.point;
		} else
		{
            target = ray.GetPoint(spellMaxDistance);
		}

        //Instantiate Part
        GameObject projectile = Instantiate(spell, firepoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = (target - firepoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectile, new Vector3 (Random.Range(-arcRange, arcRange),Random.Range(-arcRange, arcRange), 0), Random.Range(.5f, 2f));

	}
}
