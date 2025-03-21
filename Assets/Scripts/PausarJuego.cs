using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PausarJuego : MonoBehaviour
{
    public GameObject panelPausa;
    public bool juegoPausado = false;

    public TextMeshProUGUI Niveles;
    public int nivelActual;
    public TextMeshProUGUI Monedas;
    public int monedasConseguidas;
    private void Update()
    {
        nivelActual = PlayerPrefs.GetInt("Nivel");

        Niveles.text = "Nivel " + nivelActual.ToString();
        
        Monedas.text = monedasConseguidas.ToString()+"/10";
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(juegoPausado){
                Reanudar();
            }
            else{
                Pausar();
            }
        }
    }

    public void Pausar(){
        panelPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
    }

    public void Reanudar(){
        panelPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }

    public void Salir(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuInicial");
    }

    public void ActualizarMonedas(){
        monedasConseguidas = 0;

        for (int i = 1; i <= 10; i++)
        {

            monedasConseguidas += PlayerPrefs.GetInt("Moneda" + i, 0);
        }
    }
}
