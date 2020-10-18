using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = gameObject.transform.parent;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}


