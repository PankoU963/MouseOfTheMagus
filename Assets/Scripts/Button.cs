using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator animator;

    public GameObject door;
    public Animator doorAnimator;
    public void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Block") || other.CompareTag("Player"))
        {
            animator.SetBool("Pressed", true);
            doorAnimator.SetBool("Open", true);
            door.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Block") || other.CompareTag("Player"))
        {
            animator.SetBool("Pressed", false);
            doorAnimator.SetBool("Open", false);
            door.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
