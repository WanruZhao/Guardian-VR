using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

    public WayRoute wayroute;
    public NavMeshAgent agent;
    public bool isDead = false;
    public Animator anim;
    public int routetag;

    public int destination = -1;

	// Use this for initialization
	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.autoBraking = false;
        routetag = wayroute.routetag;
        GoToNext();
	}
	
	// Update is called once per frame
	void Update () {
        if(isDead)
        {
            agent.enabled = false;
            return;
        }
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNext();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;
        if(collision.gameObject.tag == "door")
        {
            gameObject.SetActive(false);
            return;
        }
        if(collision.collider.GetComponent<Valve.VR.InteractionSystem.Arrow>() != null)
        {
            anim.SetTrigger("Dead");
            isDead = true;
            return;
        }
    }

    void GoToNext()
    {
        // initialize spawn, move to spawn point
        if(destination == -1)
        {
            destination = -2;
            agent.SetDestination(wayroute.spawnpoint.transform.position);
        }
        // has already moved to spawn point
        else if(destination == -2)
        {
            if (wayroute.waypoints.Length != 0)
            {
                destination = 0;
                agent.SetDestination(wayroute.waypoints[destination].transform.position);
            }
            else
            {
                destination = -3;
                agent.SetDestination(wayroute.endpoint.transform.position);
            }
        }
        // has already moved to endpoint
        else if(destination == -3)
        {
            // deal with disappear or death?

            gameObject.SetActive(false);
            //anim.SetTrigger("Dead");
        }
        // moving among waypoints
        else
        {
            if(destination == wayroute.waypoints.Length - 1)
            {
                destination = -3;
                agent.SetDestination(wayroute.endpoint.transform.position);
            } else
            {
                destination++;
                agent.SetDestination(wayroute.waypoints[destination].transform.position);
            }
        }
    }

    // will be used if prefabs are designed to be recylable
    void Respawn()
    {

    }
}
