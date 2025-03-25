using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public BarraVida barraVida;
    private void Awake()
    {
        barraVida = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<BarraVida>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            barraVida.tiempoRegresivo = 0;
        }
    }
}
