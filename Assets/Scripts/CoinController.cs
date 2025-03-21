using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public bool take = false;

    public int monedaNivel;

    public Goal goal;
    void Awake()
    {
        PlayerPrefs.SetInt("Moneda1", 0);
        switch (monedaNivel)
        {
            case 1:
                if (PlayerPrefs.GetInt("Moneda1") == 1)
                {
                    take = true;
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("Moneda2") == 1)
                {
                    take = true;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Moneda3") == 1)
                {
                    take = true;
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("Moneda4") == 1)
                {
                    take = true;
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("Moneda5") == 1)
                {
                    take = true;
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt("Moneda6") == 1)
                {
                    take = true;
                }
                break;
            case 7:
                if (PlayerPrefs.GetInt("Moneda7") == 1)
                {
                    take = true;
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("Moneda8") == 1)
                {
                    take = true;
                }
                break;
            case 9:
                if (PlayerPrefs.GetInt("Moneda9") == 1)
                {
                    take = true;
                }
                break;
            case 10:
                if (PlayerPrefs.GetInt("Moneda10") == 1)
                {
                    take = true;
                }
                break;
        }
        if (take)
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            switch (monedaNivel)
            {
                case 1:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 2:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 3:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 4:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 5:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 6:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 7:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 8:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 9:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
                case 10:
                    goal.monedas[monedaNivel - 1] = true;
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
