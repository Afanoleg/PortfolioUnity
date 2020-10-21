using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMove;

    private Vector3 moveVector;

    private CharacterController ch_controller;

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CharacterMove();
    }

    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;

        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        ch_controller.Move(moveVector * Time.deltaTime);
    }

}
