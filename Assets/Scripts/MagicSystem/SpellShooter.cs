using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    public GameObject spell;
    public Transform LFirePoint, RFirePoint;
    public Camera mainCam;
    public float projectileSpeed = 50f;

    public float spellMaxDistance = 1000f;

    private Vector3 target;
    private bool leftHand;

    void Update()
    {
        //Spell 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
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

	}
}
