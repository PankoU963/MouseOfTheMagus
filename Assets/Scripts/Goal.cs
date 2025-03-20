using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public CameraController cameraController;
    public int currentLevel;

    public CheckPointController checkPointController;
    private void Awake()
    {
        checkPointController = GameObject.FindGameObjectWithTag("Manager").GetComponent<CheckPointController>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    void Start()
    {


    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Nivel", (currentLevel+1));
            PlayerPrefs.Save();
            checkPointController.NextLevel();
            Destroy(gameObject);
        }
    }
}
