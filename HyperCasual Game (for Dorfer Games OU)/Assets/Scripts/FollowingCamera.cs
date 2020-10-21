using UnityEngine;

//Позиция камеры

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;


    private void Update()
    {
        PlaceCameraToTarget();
        RotateCameraToTarget();
    }

    //Установка позиции камеры по отношению к объекту 
    private void PlaceCameraToTarget()
    {
        transform.position = target.transform.position + offset;
    }

    //Перемещение камеры к объекту по расположению
    private void RotateCameraToTarget()
    {
        Vector3 lookDirection = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}