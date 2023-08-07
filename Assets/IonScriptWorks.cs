using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonScriptWorks : MonoBehaviour
{
    public Transform leftPrent;
    public Transform buttomPrent;
    public Vector3 startingPosition = new Vector3(0.0000001f, 0.0000001f, -8f);
    public Vector3 startingVelocity = new Vector3(0f, 0f, 1f);
    public double r0 = 1.0;
    public double mass = 28.085;
    public double charge = 1.0;
    public double V = 400; // 0 to 3000
    public double U = 500; // 500 to 2000
    public double frequency = 60;

    private double massKg;
    private double chargeV;
    private double time;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        // Get the object's transform component
        Transform objectTransform = transform;

        // Change the position of the object
        objectTransform.position = startingPosition;
        velocity = startingVelocity;

        massKg = mass * 1.6605402e-27;
        chargeV = charge * 1.602e-19;
        time = 0.0;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Start();
            return;
        }

        double deltaTime = Time.deltaTime;
        time += deltaTime;

        double forceX = -(U + V * Mathf.Cos((float)(frequency * time))) * transform.position.x * chargeV / Mathf.Pow((float)r0, 2.0f);//maybe abs?
        double forceY = (U + V * Mathf.Cos((float)(frequency * time))) * transform.position.y * chargeV / Mathf.Pow((float)r0, 2.0f);//maybe abs?
        double accelerationX = (forceX / massKg) * deltaTime;
        double accelerationY = (forceY / massKg) * deltaTime;
        Vector3 acceleration = new Vector3((float)accelerationX, (float)accelerationY, 0f);
        Vector3 oldVelocity = velocity;
        try {
            velocity += acceleration * (float)deltaTime;
            transform.Translate(velocity * Time.deltaTime); 
        }
        finally {
            velocity = oldVelocity;
            transform.Translate(velocity * Time.deltaTime); 
        } //?? NAN NAN NAN KURWA NAN NIE DZIAŁA

    }
}
