using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItemSpawner : MonoBehaviour
{
    public bool interactible = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactible = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactible = false;
        }
    }
}
