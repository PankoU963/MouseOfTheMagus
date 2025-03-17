using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{
    public GameObject panelPausa;
    public bool juegoPausado = false;

    private void Update()
    {
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
        SceneManager.LoadScene("MenuInicial");
    }
}
