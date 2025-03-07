using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetos : MonoBehaviour
{
    public bool canMove;
    public Rigidbody2D objectToMove;
    public LayerMask layerMask;
    public float speedObjects;

    private string targetLayerName = "Move";
    void Start()
    {
        
        layerMask = LayerMask.GetMask("Move");
        
    }

    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;



        bool hits = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
        if (Input.GetMouseButtonDown(0) && hits)
        {
            canMove = true;
            objectToMove = hit.collider.gameObject.GetComponent<Rigidbody2D>();
        }
        if (canMove)
        {
            objectToMove.MovePosition(Vector2.Lerp(objectToMove.position, mousePosition, speedObjects * Time.deltaTime));
            objectToMove.gravityScale = 0;
        }
        if(Input.GetMouseButtonUp(0) && canMove)
        {
            canMove = false;
            objectToMove.gravityScale = 1;
            objectToMove = null;
        }

        Rigidbody2D[] allRigidbodies = FindObjectsOfType<Rigidbody2D>();

        foreach (Rigidbody2D rb in allRigidbodies)
        {
            // Verifica si el objeto está en el layer "move"
            if (rb.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
            {
                // Detiene la rotación del objeto
                rb.freezeRotation = true;
            }
            else
            {
                // Si no está en el layer "move", permite la rotación
                rb.freezeRotation = false;
            }
        }
    }
}
