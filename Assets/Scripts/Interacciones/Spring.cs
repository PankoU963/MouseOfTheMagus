using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    public AudioSource audioJump;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            animator.SetBool("Spring",true);
            rbPlayer.AddForce(new Vector2(0f,600));
            if(audioJump != null && !audioJump.isPlaying){
                audioJump.Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Spring",false);   
    }
}
