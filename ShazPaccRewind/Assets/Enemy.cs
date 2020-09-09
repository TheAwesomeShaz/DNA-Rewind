using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Basic,
        Medium,
        Hard, // that's what she said
        Boss,
    }

    float normalSpeed;
    float runSpeed;
    float waitTime = 0.5f;
   

    public NavMeshAgent agent;
    public Animator anim;

    public GameObject overlay;
    Vector3 currentTarget;

    bool detected;
   

    float viewRange;
    public Transform pathHolder;
    [SerializeField] private EnemyType enemyType = EnemyType.Basic;
    
    // Start is called before the first frame update
    void Start()
    {
        overlay.SetActive(false);
        SetInitialConditions(enemyType);
        anim.SetBool("Walking", false);
        anim.SetBool("Detected", false);

        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
           
        }

        StartCoroutine(Patrol(waypoints));

    }

    // Update is called once per frame
    void Update()
    {
        //LookToFindPlayer();
        SetTarget();
    }

   

    IEnumerator Patrol(Vector3[] waypoints)
    {
        currentTarget = waypoints[0];
        Debug.Log("Current Target is " + currentTarget);
        int nextWaypointIndex = 1;
        currentTarget = waypoints[nextWaypointIndex];

        while (!detected)
        {
            agent.SetDestination(waypoints[nextWaypointIndex]);
            if (transform.position == currentTarget)
            {
                nextWaypointIndex = (nextWaypointIndex + 1) % waypoints.Length;
                currentTarget = waypoints[nextWaypointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            if (detected)
            {
                anim.SetBool("Walking", true);
                anim.SetBool("Detected", true);
                agent.speed = runSpeed;
                break;
            }
            yield return null;
        }
    }

    private void SetTarget()
    {
        agent.SetDestination(currentTarget);
        

        anim.SetBool("Walking", true);
        agent.speed = normalSpeed;
            
        
    }

    private void LookToFindPlayer()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, viewRange))
        {
            if (hit.transform.GetComponent<Player>())
            {
                currentTarget = hit.transform.position;
                
                anim.SetBool("Walking", true);
                anim.SetBool("Detected", true);
                agent.speed = runSpeed;

            }
        }
        
    }

    void SetInitialConditions(EnemyType enemy)
    {
        if(enemy == EnemyType.Basic)
        {
            //basic enemy initial conditions
            viewRange = 50f;
        }
        else if(enemy == EnemyType.Medium)
        {
            //Med enemy initial conditions
            viewRange = 70f;
            normalSpeed = 10f;
            runSpeed = 50;

        }
        else if (enemy == EnemyType.Hard)
        {
            //Hard enemy initial Conditions
            viewRange = 100f;
        }
        else if (enemy == EnemyType.Boss)
        {
            //Boss enemy initial conditions
        }
    }
}
