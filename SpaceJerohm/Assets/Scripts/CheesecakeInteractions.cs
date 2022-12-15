using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesecakeInteractions : MonoBehaviour
{
    private IEnumerator coroutine;
    public void BarrelRoll()
    {
        coroutine = Rotate(2f);
        StartCoroutine(coroutine);
    }
    IEnumerator Rotate(float duration) {
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        while ( t  < duration )
        {
            t += Time.deltaTime;
            transform.root.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.back); //or transform.right if you want it to be locally based
            yield return null;
        }
        transform.rotation = startRot;
    }
}
