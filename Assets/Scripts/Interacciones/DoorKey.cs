using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject key;
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<Variables>().key)
            {
                key = other.GetComponent<Variables>().actualKey;
                if (Vector3.Distance(other.transform.position, key.transform.position) < 2f)
                {
                    Destroy(key.gameObject);
                    Destroy(gameObject);
                    other.GetComponent<Variables>().key = false;
                    other.GetComponent<Variables>().actualKey = null;
                }
            }
        }
    }
}
