using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public bool take = false;

    public CoinManager coinManager;

    void Awake()
    {
        coinManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<CoinManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(take){
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            take = true;
            coinManager.coinTake.Add(gameObject);            
            gameObject.SetActive(false);
        }
    }
}
