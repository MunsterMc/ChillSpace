using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheesecake : MonoBehaviour
{
    public CheesecakeController cheesecakeScript;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            cheesecakeScript.fetchBall(this.gameObject);
        }
        
    }
}
