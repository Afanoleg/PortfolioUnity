using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    
    [SerializeField]
    [Range (2, 6)]
    public float stepSpeed = 4;
    [Range (4, 6)]
    public float runSpeed = 8;

    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            SetTargetPosition();
        }
        if(isMoving)
        {
            
            Move();
        }
    }

    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, stepSpeed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
