using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public CameraController cameraController;
    public int currentLevel;
    public List<bool> monedas = new List<bool>(new bool[10]); 

    public CheckPointController checkPointController;

    private PausarJuego checkMonedas;
    private void Awake()
    {
        checkMonedas = GameObject.FindGameObjectWithTag("Pause").GetComponent<PausarJuego>();
        checkPointController = GameObject.FindGameObjectWithTag("Manager").GetComponent<CheckPointController>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    void Start()
    {
        checkMonedas.ActualizarMonedas();

    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (monedas[currentLevel - 1])
            {
                switch (currentLevel)
                {
                    case 1:
                        PlayerPrefs.SetInt("Moneda1", 1);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("Moneda2", 1);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("Moneda3", 1);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("Moneda4", 1);
                        break;
                    case 5:
                        PlayerPrefs.SetInt("Moneda5", 1);
                        break;
                    case 6:
                        PlayerPrefs.SetInt("Moneda6", 1);
                        break;
                    case 7:
                        PlayerPrefs.SetInt("Moneda7", 1);
                        break;
                    case 8:
                        PlayerPrefs.SetInt("Moneda8", 1);
                        break;
                    case 9:
                        PlayerPrefs.SetInt("Moneda9", 1);
                        break;
                    case 10:
                        PlayerPrefs.SetInt("Moneda10", 1);
                        break;
                }
            }
            PlayerPrefs.SetInt("Nivel", (currentLevel+1));
            if(currentLevel >= PlayerPrefs.GetInt("NivelMaximo"))
            {
                if (currentLevel <= 10) 
                {
                    PlayerPrefs.SetInt("NivelMaximo", currentLevel + 1);
                }
            }
            PlayerPrefs.Save();
            checkPointController.NextLevel();
            checkMonedas.ActualizarMonedas();
            Destroy(gameObject);
                
        }
    }
}
