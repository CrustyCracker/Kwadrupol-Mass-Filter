using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadrupoleForce : MonoBehaviour
{
    public float q = 1.0f; // charge of the ion
    public float E = 1.0f; // electric field strength
    public float r0 = 1.0f; // characteristic length scale
    public Transform centralAxis; // transform of the central axis of the quadrupole field

    private Rigidbody rb; // rigidbody component of the ion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // calculate distance from ion to central axis
        Vector3 displacement = rb.position - centralAxis.position;
        float rz = displacement.magnitude;

        // calculate force magnitude
        float forceMag = q * E * (2 * rz / (r0 * r0));

        // calculate force direction
        Vector3 forceDir = displacement.normalized;

        // apply force to ion
        rb.AddForce(forceMag * forceDir);
    }
}
