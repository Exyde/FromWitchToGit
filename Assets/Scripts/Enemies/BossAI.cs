using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{

    // Documentation : https://www.youtube.com/watch?v=UjkSFoLxesw - Dave, Gamedev
    // Documentation : https://www.youtube.com/watch?v=z20wHJSXk98&t=246s - Lague Platformer
    // Doc : https://www.youtube.com/watch?v=jUdx_Nj4Xk0 - Stealth Lague

    Transform player;

    public Vector3[] localWaypoints;
    Vector3[] globalWaypoints;

    public LayerMask groundLayer, playerLayer;

    [Header("Patrolling ")]
    public float speed = 8f;
    Vector3 targetWaypoint;
    int targetWaypointIndex;

    [Header("Attacking")]
    public float timeBtwAttack;
    bool alreadyAttacked;
    public Transform firePoint;
    public GameObject attackPrefab;

    [Header("States")]
    [Range (0, 50)]
    public float viewRange;
    [Range (0, 50)]
    public float attackRange;

    [Header("Debug")]
    public bool playerInView;
    public bool playerInAttackRange;

    Animator animator;

    private void Awake()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;

        globalWaypoints = new Vector3[localWaypoints.Length];

        //Cache the local array in world pos, used for navigate.
        for (int i = 0; i < localWaypoints.Length; i++)
		{
            globalWaypoints[i] = localWaypoints[i] + transform.position;
		}

        //Set the base target
        transform.position = globalWaypoints[0];
        targetWaypointIndex = 1;
        targetWaypoint = globalWaypoints[targetWaypointIndex];
        targetWaypoint.y = transform.position.y;

        //Animator
        animator = GetComponent<Animator>();
	}

    void Update()
    {
        playerInView = Physics.CheckSphere(transform.position, viewRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInView && !playerInAttackRange) Patroling();
        if (playerInView && !playerInAttackRange) ChasePlayer();
        if (playerInView && playerInAttackRange) AttackPlayer();

    }

    private void Patroling()
	{

       //Move to waypoints -- Add a check for tree ?
       transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
       transform.LookAt(targetWaypoint);


        //Get next point
        if (transform.position == targetWaypoint)
		{
            targetWaypointIndex = (targetWaypointIndex + 1) % globalWaypoints.Length;
            targetWaypoint = globalWaypoints[targetWaypointIndex];
            targetWaypoint.y = transform.position.y;
		}

	}
    private void ChasePlayer()
	{
        Vector3 playerPos = new Vector3(player.transform.position.x, transform.position.y, player.position.z);
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
	}

    private void AttackPlayer()
	{
        
        transform.LookAt(player);

        if (!alreadyAttacked)
		{
            animator.SetTrigger("Attack");
            //Attack Content ! 
            Rigidbody rb = Instantiate(attackPrefab, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();

            Vector3 dir = (player.position - firePoint.position).normalized;
            rb.AddForce(32f * dir, ForceMode.Impulse);
            //rb.AddForce(transform.up * .5f, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBtwAttack);
		}
	}

    private void ResetAttack()
	{
        alreadyAttacked = false;
        animator.SetTrigger("Patrol");
	}

    private void OnDrawGizmos()
	{
        //View & Attack Range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawSphere(firePoint.position, .2f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRange);

        //Paths and Waypoints
        if (localWaypoints != null)
		{
            Vector3 startPosition = (Application.isPlaying) ? globalWaypoints[0] : localWaypoints[0] + transform.position;
            Vector3 previousPosition = startPosition;

            Gizmos.color = Color.cyan;
            float size = .2f;

            for (int i = 0; i < localWaypoints.Length; i++)
			{
                Vector3 globalWaypointPos = (Application.isPlaying) ? globalWaypoints[i] : localWaypoints[i] + transform.position;
                Gizmos.DrawSphere(globalWaypointPos, size);
                Gizmos.DrawLine(previousPosition, globalWaypointPos);
                previousPosition = globalWaypointPos;
			}

            
            Gizmos.DrawLine(previousPosition, startPosition);

        }

        //Sight of view
        if (Application.isPlaying)
            Debug.DrawLine(firePoint.position, player.position);
    }
}
