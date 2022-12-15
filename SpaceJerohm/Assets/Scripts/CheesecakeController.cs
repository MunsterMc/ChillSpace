using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CheesecakeController : MonoBehaviour
{
    private Vector3 target;
    private NavMeshAgent nav;
    [SerializeField] private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void SetNewTarget(GameObject newTarget)
    {
        target = newTarget.transform.position;
        
        transform.LookAt(target);
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
