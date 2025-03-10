using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    [Range(0f,0.3f)][SerializeField] private float smoothness;
    private float movementH = 0f;
    private Boolean lookRight = true;
    private Vector3 speed = Vector3.zero;
    [SerializeField]PhysicsMaterial2D slipperyMaterial;
    [SerializeField]PhysicsMaterial2D normalMaterial;
    private Collider2D collider;

    [Header("Jump")]

    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask isFloor;
    [SerializeField] private LayerMask isAlsoFloor;
    [SerializeField] private Transform floorController;
    [SerializeField] private Vector3 boxDimension;
    [SerializeField] private bool onFloor;
    [SerializeField] private bool onPlataform;
    private Boolean jump = false;

    
    void Start()
    {        
        // tomamos los componente rigidbody y collider
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //se congela la rotacion
        rb.freezeRotation = true;

        movementH = Input.GetAxis("Horizontal")*movementSpeed;
        
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }

        //cuando el personaje esta sobre la plataforma su material se vuelve "normal" para que este pueda desplazarse sobre la plataforma
        if(onPlataform){
            Debug.Log("sexo");
            collider.sharedMaterial = normalMaterial;
        }else{
            collider.sharedMaterial = slipperyMaterial;
        }
        
    }

    void FixedUpdate()
    {
        rb.freezeRotation = true;
        //sirve para saber si el floor del personaje atraviesa el suelo
        onFloor = Physics2D.OverlapBox(floorController.position, boxDimension, 0f, isFloor + isAlsoFloor);

        //sirve para saber si el floor del personaje atraviesa la plataforma
        onPlataform = Physics2D.OverlapBox(floorController.position, boxDimension, 0f, isAlsoFloor);

        Move(movementH * Time.fixedDeltaTime, jump);

        jump = false;
    }

    void Move(float movement, bool jump)
    {
        Vector3 Velocity = new Vector2(movement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, Velocity, ref speed, smoothness);

        if(movement < 0 && !lookRight){
            Turn();
        }
        else if(movement > 0 && lookRight){
            Turn();
        }
        
        //se hace la comprobacion para saber si la persona esta tocando suelo y si jump es verdadero para poder saltar
        if(onFloor && jump){
            
            rb.AddForce(new Vector2(0f,jumpForce));
            onFloor = false;
        }

        
    }

    //sirve para girar el modelo del personaje al mover de izquierda a derecha
    private void Turn(){
        lookRight = !lookRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //dibuja un gizmo para poder conocer los bordes del hijo de player floor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorController.position,boxDimension);
    }
}
