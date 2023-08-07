using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonScript : MonoBehaviour
{

    
    public Vector3 startPosition;
    public Vector3 startVelocity;
    public float mass;
    public float charge;
    public float U;
    public float V;
    public float f;
    private Rigidbody rb;
    public Vector3 force;


    private float lastZ;
    private float lastY;
    private float lastPotentialZ;
    private float lastPotentialY;
    public float t;
    public float startingVelZ = 0;
    public float startingVelY = 0;

    float calculatePotential(bool zAxis, float t)
    {
        float calc = U - V * Mathf.Cos(f *2* Mathf.PI * t/60);

        if (zAxis)
        {
            return calc;
        }
        else return -1 * calc;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = startPosition;
        rb.velocity = startVelocity;
        rb.mass = mass;
        force = Vector3.zero;
        t = 0;
        
     lastZ = startingVelZ;
     lastY = startingVelY;
     lastPotentialZ = calculatePotential(true, t);
     lastPotentialY = calculatePotential(false, t);
}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Start();
            return;
        }
        t += 1;
        float nowZ = rb.position[2];
        float nowY = rb.position[1];
        float nowPotentialZ = calculatePotential(true, t);
        float nowPotentialY = calculatePotential(false, t);

        float ForceZ = -1 * charge * (nowPotentialZ - lastPotentialZ) / (nowZ - lastZ);
        float ForceY = -1 * charge * (nowPotentialY - lastPotentialY) / (nowY - lastY);
        force = new Vector3(0.0f, ForceY, ForceZ);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(force);

        lastPotentialY = nowPotentialY;
        lastPotentialZ = nowPotentialY;
        lastY = nowY;
        lastZ = nowZ;













    }

}
