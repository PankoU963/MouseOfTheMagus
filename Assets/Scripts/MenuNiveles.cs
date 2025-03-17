using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void Nivel(int index){
        // Debug.Log("Entrando al nivel " + index);


        PlayerPrefs.SetInt("Nivel", index);
        Debug.Log(PlayerPrefs.GetInt("Nivel"));
        PlayerPrefs.Save();

        SceneManager.LoadScene(1); //Carga la escena de los 10 niveles
        
    }
}
