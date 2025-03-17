using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public Image rellenoBarraVida;

    public float tiempoMax = 120f;
    private float tiempoRegresivo;



    // Start is called before the first frame update
    void Start()
    {
        tiempoRegresivo = tiempoMax;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRegresivo -= Time.deltaTime;
        rellenoBarraVida.fillAmount = tiempoRegresivo / tiempoMax;
    }
}
