using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    // Documentation : https://www.youtube.com/watch?v=UjkSFoLxesw - Dave, Gamedev
    // Documentation : https://www.youtube.com/watch?v=z20wHJSXk98&t=246s - Lague Platformer

    NavMeshAgent agent;
    Transform player;

    public LayerMask groundLayer, playerLayer;

    [Header("Patrolling ")]
    Vector3 targetWalkPoint;
    bool targetWalkPointSet;
    public float targetWalkPointRange;

    [Header("Attacking")]
    public float timeBtwAttack;
    bool alreadyAttacked;
    public Transform firePoint;
    public GameObject attackPrefab;

    [Header("States")]
    public float viewRange, attackRange;
    public bool playerInView, playerInAttackRange;

    private void Awake()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
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
        if (!targetWalkPointSet) FindWalkPoint();

        if (targetWalkPointSet) agent.SetDestination(targetWalkPoint);

        Vector3 distanceToWalkPoint = transform.position - targetWalkPoint; 
        if (distanceToWalkPoint.magnitude < 1f)
		{
            targetWalkPointSet = false;
		}
	}

    void FindWalkPoint()
	{
        //Random version :
        float randZ = Random.Range(-targetWalkPointRange, targetWalkPointRange);
        float randX = Random.Range(-targetWalkPointRange, targetWalkPointRange);

        targetWalkPoint = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);

        //check if target is on the ground :
        if (Physics.Raycast(targetWalkPoint, -transform.up, 2f, groundLayer))
		{
            targetWalkPointSet = true;
		}

    }

    private void ChasePlayer()
	{
        agent.SetDestination(player.position);
	}

    private void AttackPlayer()
	{
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
		{
            //Attack Content ! 
            Rigidbody rb = Instantiate(attackPrefab, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * .5f, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBtwAttack);
		}
	}

    private void ResetAttack()
	{
        alreadyAttacked = false;
	}

    private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawSphere(firePoint.position, .2f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRange);
    }
}
