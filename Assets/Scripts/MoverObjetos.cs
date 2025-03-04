using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetos : MonoBehaviour
{
    public bool canMove;
    public Rigidbody2D objectToMove;
    public LayerMask layerMask;
    public float speedObjects;
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
        if (Input.GetMouseButton(0) && hits)
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
    }
}
