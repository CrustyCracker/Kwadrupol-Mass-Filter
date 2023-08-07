using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IonStabilityScript : MonoBehaviour
{
    public TMP_InputField vInputField;
    public TMP_InputField uInputField;
    public TMP_InputField chargeInputField;
    public TMP_InputField massInputField;
    public Transform leftPrent;
    public Transform buttomPrent;
    public Vector3 startingPosition = new Vector3(0.0f, 0.0f, -8f);
    public Vector3 startingVelocity = new Vector3(0f, 0f, 1f);
    public double r0 = 1.0;
    public float mass;
    public float charge;
    public float V; // 0 to 3000
    public float U; // 500 to 2000
    public float frequency = 3;


    private float amplitude = 0.25f;
    private float getOutFactor;
    private float xAmplitude;
    private float yAmplitude;
    private Vector3 velocity;
    
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {

        //Initialize UI 
        uInputField.onEndEdit.AddListener(HandleUInput);
        vInputField.onEndEdit.AddListener(HandleVInput);
        massInputField.onEndEdit.AddListener(HandleMassInput);
        chargeInputField.onEndEdit.AddListener(HandleChargeInput);

        InitBall();


    }

    void InitBall()
    {
        // Get the object's transform component
        Transform objectTransform = transform;

        // Change the position of the object
        objectTransform.position = startingPosition;
        velocity = startingVelocity;
        xAmplitude = amplitude;
        yAmplitude = amplitude;
        isPaused = true;



    }

    private void OnDestroy()
    {
        vInputField.onEndEdit.RemoveListener(HandleVInput);
        uInputField.onEndEdit.RemoveListener(HandleUInput);
        chargeInputField.onEndEdit.RemoveListener(HandleChargeInput);
        massInputField.onEndEdit.RemoveListener(HandleMassInput);
    }

    public void HandleVInput(string input)
    {
        // Use the input as needed
        Debug.Log("Received V input: " + input);

        U = float.Parse(input);

    }
    public void HandleUInput(string input)
    {
        // Use the input as needed
        Debug.Log("Received U input: " + input);

        V = float.Parse(input);

    }
    public void HandleChargeInput(string input)
    {
        // Use the input as needed
        Debug.Log("Received charge input: " + input);

        charge = float.Parse(input);

    }
    public void HandleMassInput(string input)
    {
        // Use the input as needed
        Debug.Log("Received mass input: " + input);

        mass = float.Parse(input);

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InitBall();
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            getOutFactor = 0.00019f * charge;
            isPaused = !isPaused;
        }

        if (!isPaused)
        {
            transform.Translate(velocity * Time.deltaTime);

            Vector3 currentPosition = transform.position;

            // Create a new position with only the Y value changed
            Vector3 newYPosition = new Vector3(xAmplitude * Mathf.Sin(frequency * Time.time), yAmplitude *Mathf.Sin(frequency * Time.time), currentPosition.z);

            // Assign the new position to the transform
            transform.position = newYPosition;

            if(mass < 30)
            {
                xAmplitude += getOutFactor;
            }else if(mass > 100)
            {
                yAmplitude += getOutFactor;
            }
            

            if(Mathf.Abs(transform.position.x) > r0 || Mathf.Abs(transform.position.y) > r0){
                isPaused = true;
            }
        }
    }
}
