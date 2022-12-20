using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CheesecakeController : MonoBehaviour
{
    private bool isWalking = false;
    Animator animator;
    private Vector3 target;
    private NavMeshAgent nav;
    [SerializeField] private GameObject ballPrefab;

    void Start()
    {
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if ( nav.enabled && isWalking )
        {
            if (nav.remainingDistance < 0.5f)
            {
                animator.SetBool("walking", false);
            }
        }
    }

    private void SetNewTarget(GameObject newTarget)
    {
        target = newTarget.transform.position;
        
        transform.LookAt(target);
        animator.SetBool("walking", true);
        nav.SetDestination(target);
    }

    public void fetchBall(GameObject ball)
    {
        SetNewTarget(ball);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.name.Contains("Ball") )
        {
            other.transform.position = new Vector3(0, 0.8f, 0.8f);
        }
    }
}
