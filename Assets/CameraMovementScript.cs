using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

  
    public float camera_speed = 5.0f;
    public float camera_sensitivity = 5.0f;
    private bool cameraLocked = false;



    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cameraLocked = !cameraLocked;
            Cursor.visible = !Cursor.visible;
        }

        // Move the camera forward, backward, left, and right
        if (!cameraLocked)
        {
            transform.position += transform.forward * Input.GetAxis("Vertical") * camera_speed * Time.deltaTime;
            transform.position += transform.right * Input.GetAxis("Horizontal") * camera_speed * Time.deltaTime;

            // Rotate the camera based on the mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.eulerAngles += new Vector3(-mouseY * camera_sensitivity, mouseX * camera_sensitivity, 0);
        }
    }
}
