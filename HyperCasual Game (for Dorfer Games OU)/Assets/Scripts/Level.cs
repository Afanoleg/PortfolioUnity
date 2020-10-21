using UnityEngine;

//Скрипт отвечающий за уровень и окружение
public class Level : MonoBehaviour
{
    [SerializeField] private GameObject sphereLandingPoint;
    [SerializeField] private float maxBallDistance;

    public GameObject SphereLandingPoint => sphereLandingPoint;
    public float MaxBallDistance => maxBallDistance;

    //Перезапуск уровня
    public void Activate(Vector3 position)
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = position;
        gameObject.SetActive(true);
    }

    //Убирает уровень
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}