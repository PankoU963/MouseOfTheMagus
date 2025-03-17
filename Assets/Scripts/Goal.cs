using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public CameraController cameraController;
    public int currentLevel;

    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Nivel");
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            currentLevel++;
            cameraController.target.position += new Vector3((currentLevel-1) * 18,0,0);
            PlayerPrefs.SetInt("Nivel", currentLevel);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }
}
