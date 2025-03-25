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

        if(Input.GetKeyDown(KeyCode.R)){
            tiempoRegresivo = 0;
        }
    }

    public void LevelCompleted()
    {
        tiempoRegresivo = tiempoMax;
    }
}
