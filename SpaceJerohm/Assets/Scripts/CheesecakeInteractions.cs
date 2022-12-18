using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;

public class CheesecakeInteractions : MonoBehaviour
{
    private IEnumerator _coroutine;
    private NavMeshAgent nav;
    [SerializeField] private Transform center;
    [SerializeField] private Transform rotPos1;
    [SerializeField] private Transform rotPos2;
    [SerializeField] private GameObject cheese;
    [SerializeField] private Transform bed;

    private void Start()
    {
        nav = cheese.GetComponent<NavMeshAgent>();
    }

    public void BarrelRoll()
    {
        _coroutine = Rotate(2f);
        StartCoroutine(_coroutine);
    }
    IEnumerator Rotate(float duration) {
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        Vector3 rotationVector = rotPos1.position - rotPos2.position;
        nav.enabled = !nav.enabled;
        while ( t  < duration )
        {
            t += Time.deltaTime;
            cheese.transform.RotateAround(center.position, rotationVector, t * 2.6f);
            yield return null;
        }
        transform.rotation = startRot;
        nav.enabled = !nav.enabled;
    }

    public void PlayDead()
    {
        _coroutine = Dead(2f);
        StartCoroutine(_coroutine);
    }

    IEnumerator Dead(float duration)
    {
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        Vector3 rotationVector = rotPos1.position - rotPos2.position;
        nav.enabled = !nav.enabled;
        transform.root.RotateAround(center.position, rotationVector, 180f);
        while (t < duration)
        {
            t += Time.deltaTime;
            yield return null;
        }
        
        transform.rotation = startRot;
        nav.enabled = !nav.enabled;
    }


    public void Sleep()
    {
        _coroutine = goToSleep();
        StartCoroutine(_coroutine);
    }

    IEnumerator goToSleep()
    {
        nav.SetDestination(bed.position);
        yield return null;
    }
}
