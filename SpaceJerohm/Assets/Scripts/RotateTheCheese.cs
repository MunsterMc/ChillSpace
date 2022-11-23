using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTheCheese : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*gameObject.transform.Rotate(0.3f, 0.4f, 0.1f);*/
        rb.velocity = new Vector3(0f, 0f, -10);
        /*rb.AddExplosionForce(40, new Vector3(0, 0, 2), 40);*/
    }
}
