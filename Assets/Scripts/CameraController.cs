using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public new Camera camera;
    public Rigidbody2D rigidCamera;
    public float speedCamera;
    public Transform target;
    public void Start()
    {
        camera = Camera.main;
        camera.transform.position = new Vector3(0,0,-10);
        rigidCamera = camera.GetComponent<Rigidbody2D>();
        target.position = camera.transform.position;
    }

    public void Update()
    {
        LevelCompleted();
    }

    public void LevelCompleted()
    {
        rigidCamera.MovePosition(Vector2.MoveTowards(camera.transform.position, target.position, speedCamera* Time.deltaTime));
    }

}
