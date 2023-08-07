using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Transform lookAtTranform;
    private cameraPos currentPos = cameraPos.pos1;
    private enum cameraPos
    {
        pos1,
        pos2,
        pos3,
        total
    }
   

    // Update is called once per frame
    void Update()
    {
        bool right = Input.GetButtonDown("Fire2");

        if (right)
        {
            currentPos = (cameraPos)(((int)currentPos + 1) % (int)cameraPos.total);
        }

        switch (currentPos)
        {
            case cameraPos.pos1:
                transform.position = pos1;   
                break;
            case cameraPos.pos2:
                transform.position = pos2;
                break;
            case cameraPos.pos3:
                transform.position = pos3;
                break;
        }
        transform.LookAt(lookAtTranform);








    }
}
