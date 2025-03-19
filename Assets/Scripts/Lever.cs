using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator animator;

    public GameObject door;
    public Animator doorAnimator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                animator.SetBool("On", true);
                doorAnimator.SetBool("Open", true);
                door.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }
}
