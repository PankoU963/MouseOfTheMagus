using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public new Camera camera;
    public Rigidbody2D rigidCamera;
    public float speedCamera;
    public Transform target;

    public int nivel;

    private void Awake()
    {

    }

    public void Start()
    {

        camera = Camera.main;
        rigidCamera = camera.GetComponent<Rigidbody2D>();
        nivel = PlayerPrefs.GetInt("Nivel");
        
        if(nivel == 0 || nivel == 1)
        {
            camera.transform.position = new Vector3(0,0,-10);
            target.position = camera.transform.position;
        } else if (nivel < 11 && nivel >= 2)
        {
            camera.transform.position = new Vector3(18 * (nivel-1),0,-10);
            target.position = camera.transform.position;
        }
    }

    public void Update()
    {
        LevelCompleted();
    }

    public void LevelCompleted()
    { 
        target.position = new Vector3(18 * (PlayerPrefs.GetInt("Nivel")-1),0,-10);
        rigidCamera.MovePosition(Vector2.MoveTowards(camera.transform.position, target.position, speedCamera* Time.deltaTime));
    }

}
