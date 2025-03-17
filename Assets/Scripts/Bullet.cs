using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigid;
    public int shootSpeed;
    public float autoDestroy;


    private int direction;

    //DIRECTION
    public Turret turret;
    void Start()
    {
        turret = gameObject.GetComponentInParent<Turret>();
        bulletRigid = gameObject.GetComponent<Rigidbody2D>();
        shootSpeed = 1000;
        autoDestroy = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(turret.left)
        {
            direction = 1;
        }
        if(turret.left == false)
        {
            direction = -1;
        }
        autoDestroy -= Time.deltaTime; 
        bulletRigid.velocity = (Vector2.left * direction) * shootSpeed * Time.deltaTime;
        if(autoDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
