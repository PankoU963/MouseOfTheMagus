using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float shootTime;
    public float shoot;

    public bool left;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(left)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if(left==false)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        shoot -= Time.deltaTime;
        if(shoot <= 0)
        {
            Shoot();
            shoot = shootTime;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform);
    }

}
