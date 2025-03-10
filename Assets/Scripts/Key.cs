using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(player.GetComponent<Variables>().key == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y +1.5f), 3f* Time.deltaTime);
            }
        }

    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Variables>().key = true;
            other.GetComponent<Variables>().actualKey = transform.gameObject;
        }
    }
}
