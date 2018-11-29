using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    UnityEngine.AI.NavMeshAgent nav;
    private bool dead = false;
    Animator anim;


    void Awake ()
    {
        target = GameObject.FindWithTag("TempBall").transform;
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        if (dead) {
            nav.enabled = false;
            return;
        }
        nav.SetDestination (target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (dead) return;
        // set Dead
        if (collision.collider.GetComponent<Valve.VR.InteractionSystem.Arrow>() != null)
        {
            anim.SetTrigger("Dead");
            dead = true;
        }
    }
}
