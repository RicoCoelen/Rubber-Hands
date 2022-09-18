using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] public Transform desiredPosition;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField] private bool wandering = false;
    /// <summary>
    /// Awake to assign variables locally for the fixedupdate() to use
    /// </summary>
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// updates the movement of actor, and passes the variables to unity mechanim animator controller
    /// </summary>
    private void FixedUpdate()
    {
        if (wandering == false)
        {
            if (desiredPosition && navMeshAgent.enabled)
            {
                navMeshAgent.destination = desiredPosition.position;
            }
            animator.SetFloat("Velocity", navMeshAgent.velocity.magnitude);
        }
        else
        {// keep creating new points to walk to
            if (desiredPosition && navMeshAgent.enabled)
            {
                navMeshAgent.destination = desiredPosition.position;
            }
            animator.SetFloat("Velocity", navMeshAgent.velocity.magnitude);
        }
    }
}
