using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotationSpeed;
    public float Max;
    public float Min;
    public Quaternion camRotation;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        camRotation.x += Input.GetAxisRaw("RotateY") * rotationSpeed * Time.deltaTime;
        camRotation.x = Mathf.Clamp(camRotation.x, Min, Max);
        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
