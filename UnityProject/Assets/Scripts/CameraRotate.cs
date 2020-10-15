using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Joystick JoyStick;
    public float rotationSpeed;
    public float Max;
    public float Min;
    public Quaternion camRotation;
    // Start is called before the first frame update
    void Start()
    {
        //gets inital camera rotation
        camRotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //checks for platform to change automatically, so when building or changing platforms it doesnt cause conflicts
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WebGLPlayer 
            || Application.platform == RuntimePlatform.WindowsEditor)
            camRotation.x += Input.GetAxisRaw("RotateY") * rotationSpeed * Time.deltaTime;
        else
            camRotation.x += JoyStick.Vertical * rotationSpeed * Time.deltaTime;

        camRotation.x = Mathf.Clamp(camRotation.x, Min, Max);
        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
