using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public Image rellenoBarraVida;

    public float tiempoMax;
    public float tiempoRegresivo;

    public bool ChangeLevel;

    private bool flag = true;

    public CheckPointController checkPointController;
    // Start is called before the first frame update

    private void Awake()
    {
        checkPointController = GameObject.FindGameObjectWithTag("Manager").GetComponent<CheckPointController>();
        tiempoMax = 15f;
    }
    void Start()
    {
        switch (PlayerPrefs.GetInt("Nivel"))
        {
            case 1:
                tiempoMax = 15f;
                break;
            case 2:
                tiempoMax = 15f;
                break;
            case 3:
                tiempoMax = 15f;
                break;
            case 4:
                tiempoMax = 15f;
                break;
            case 5:
                tiempoMax = 15f;
                break;
            case 6:
                tiempoMax = 15f;
                break;
            case 7:
                tiempoMax = 15f;
                break;
            case 8:
                tiempoMax = 15f;
                break;
            case 9:
                tiempoMax = 60f;
                break;
            case 10:
                tiempoMax = 15f;
                break;
        }
        tiempoRegresivo = tiempoMax;

    }

    // Update is called once per frame
    void Update()
    {
        if(ChangeLevel == false)
        {
            tiempoRegresivo -= Time.deltaTime;
            rellenoBarraVida.fillAmount = tiempoRegresivo / tiempoMax;
        }

        switch (PlayerPrefs.GetInt("Nivel"))
        {
            case 1:
                tiempoMax = 15f;
                break;
            case 2:
                tiempoMax = 15f;
                break;
            case 3:
                tiempoMax = 15f;
                break;
            case 4:
                tiempoMax = 15f;
                break;
            case 5:
                tiempoMax = 15f;
                break;
            case 6:
                tiempoMax = 15f;
                break;
            case 7:
                tiempoMax = 15f;
                break;
            case 8:
                tiempoMax = 15f;
                break;
            case 9:
                tiempoMax = 60f;
                break;
            case 10:
                tiempoMax = 15f;
                break;
        }

        if(Input.GetKeyDown(KeyCode.R)){
            tiempoRegresivo = 0;
        }
    }

    public void LevelCompleted()
    {
        tiempoRegresivo = tiempoMax;
    }
}
