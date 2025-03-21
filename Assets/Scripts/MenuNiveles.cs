using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public GameObject[] Niveles;

    public void Start()
    {
        if(PlayerPrefs.GetInt("NivelMaximo") == 0){
            PlayerPrefs.SetInt("NivelMaximo",1);
        }
    }

    void Update()
    {
        foreach(GameObject niv in Niveles){
            niv.SetActive(false);
        }
        Debug.Log(PlayerPrefs.GetInt("NivelMaximo"));
        for (int i = 1; i <= PlayerPrefs.GetInt("NivelMaximo"); i++)
        {
            Niveles[i-1].SetActive(true);
        }
    }
    public void Nivel(int index){
        // Debug.Log("Entrando al nivel " + index);


        PlayerPrefs.SetInt("Nivel", index);
        PlayerPrefs.Save();

        SceneManager.LoadScene(1); //Carga la escena de los 10 niveles
        
    }
}
