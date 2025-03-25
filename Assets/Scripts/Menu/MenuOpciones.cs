using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

    public void PantallaCompleta(bool pantallaCompleta){
        Screen.fullScreen = pantallaCompleta;        
    }

    public void CambiarVolumen(float volumen){
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void CambiarCalidad(int index){
        QualitySettings.SetQualityLevel(index);
    }

    public void Reset()
    {
        for(int i = 1;  i <= 10; i++)
        {
            PlayerPrefs.SetInt("Moneda"+i,0);
        }
        PlayerPrefs.SetInt("Nivel",1);
        PlayerPrefs.SetInt("NivelMaximo",1);
        PlayerPrefs.Save();
    }
}
