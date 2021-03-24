using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouleAI : MonoBehaviour
{
    public bool running = false;
    public bool walking = false;
    public bool idle = false;
    Animator anim;
    Transform player;

    public Vector3[] localWaypoints;
    Vector3[] globalWaypoints;

    [Header("Patrolling ")]
    public float speed = 8f;
    public float waitTime = .5f;
    Vector3 targetWaypoint;
    int targetWaypointIndex;

    public bool drawGizmos = false;


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
    }
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("PoulePatrol", -1, Random.Range(0f, 4f));

    }

    void Update()
    {
        if (running)
            Patroling();
    }

    private void Patroling()
    {
        //Move to waypoints -- Add a check for tree ?
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
        transform.LookAt(targetWaypoint);


        //Get next point
        if (transform.position == targetWaypoint)
        {
            StartCoroutine(WaitForPatrol());
        }

    }

    IEnumerator WaitForPatrol()
    {
        running = false;
        targetWaypointIndex = (targetWaypointIndex + 1) % globalWaypoints.Length;
        targetWaypoint = globalWaypoints[targetWaypointIndex];
        targetWaypoint.y = transform.position.y;
        yield return new WaitForSeconds(waitTime);
        running = true;
    }

    private void OnDrawGizmos()
    {
        //Paths and Waypoints
        if (localWaypoints != null && drawGizmos)
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
    }
}