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
        cameraController = Camera.main.GetComponent<CameraController>();
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
            Destroy(gameObject);
        }
    }
}
