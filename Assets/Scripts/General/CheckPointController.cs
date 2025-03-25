using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointController : MonoBehaviour
{
    public int nivel;

    public GameObject[] checkPoints;
    public GameObject currentCheckPoint;

    public GameObject player;
    public BarraVida barraVida;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        barraVida = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<BarraVida>();
    }
    void Start()
    {
        if (nivel == 11)
        {
            PlayerPrefs.SetInt("Nivel", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MenuInicial");
        }
        if (nivel <= 10)
        {
            currentCheckPoint = checkPoints[PlayerPrefs.GetInt("Nivel") - 1];
            player.transform.position = currentCheckPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        nivel = PlayerPrefs.GetInt("Nivel");
        if (nivel == 11)
        {
            PlayerPrefs.SetInt("Nivel", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MenuInicial");
        }

        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (i == nivel)
            {
                currentCheckPoint = checkPoints[i-1];
            }
        }
        if(nivel == 10)
        {
            currentCheckPoint = checkPoints[9];
        }

        if (Vector3.Distance(player.transform.position, currentCheckPoint.transform.position) < 0.5f && player.GetComponent<PlayerMovement>().enabled == false)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            barraVida.ChangeLevel = false;
            barraVida.LevelCompleted();
        }

        if (barraVida.ChangeLevel)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, currentCheckPoint.transform.position, 5 * Time.deltaTime);
        }

        if(barraVida.tiempoRegresivo <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

    public void NextLevel()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        barraVida.ChangeLevel = true;
        //player.GetComponent<Rigidbody2D>().MovePosition(Vector3.Lerp(player.GetComponent<Rigidbody2D>().position, currentCheckPoint.transform.position, 10 * Time.deltaTime));
    }
}
