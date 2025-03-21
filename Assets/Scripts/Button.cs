using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Block") || other.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Block") || other.CompareTag("Player"))
        {
            door.SetActive(true);
        }
    }
}
