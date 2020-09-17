﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //so the movement angle of the platform can be changed
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject startingPoint;
    [SerializeField] GameObject endingPoint;

    private Rigidbody rb;
    private Vector3 towards;
    private Vector3 backwards;


    // Start is called before the first frame update
    bool hasReached = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //getting the vector to move the platform towards
        towards = Vector3.Normalize(new Vector3(
            startingPoint.transform.position.x - endingPoint.transform.position.x,
            startingPoint.transform.position.y - endingPoint.transform.position.y,
            startingPoint.transform.position.z - endingPoint.transform.position.z));

        //with reversing the minus it changes the direction of the movement eg ^ = move forward 1 unit left and up but this
        //with it being reversed makes it = move backwards 1 and down 1.
        backwards = Vector3.Normalize(new Vector3(
            endingPoint.transform.position.x - startingPoint.transform.position.x,
            endingPoint.transform.position.y - startingPoint.transform.position.y,
            endingPoint.transform.position.z - startingPoint.transform.position.z));
    }
    
    // Update is called once per frame
    void Update()
    {
        if (hasReached == true)
        {
             rb.MovePosition(transform.position + towards * speed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(transform.position + backwards * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            hasReached = !hasReached;
        }

    }


}