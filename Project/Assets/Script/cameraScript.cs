using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public float sensitivity;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    void Update()
    {

        CamRotX();
    }


    void CamRot()
    {

        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }


    void CamRotX()
    { 

        float xDelta = Input.GetAxis("Mouse Y");

        Vector3 vRot = transform.localRotation.eulerAngles;
        vRot.x -= xDelta * sensitivity * Time.deltaTime;
        //Mathf.Clamp(vRot.y, -maxYAngle, maxYAngle); // 범위지정

        this.transform.localRotation = Quaternion.Euler(vRot);
    }

}
