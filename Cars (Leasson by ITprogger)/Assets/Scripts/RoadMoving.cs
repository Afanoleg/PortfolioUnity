using UnityEditor;
using UnityEngine;

public class RoadMoving : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject road;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7.6f) {
            Instantiate(road, new Vector3(0, 16.49f, 1.98f), Quaternion.identity);
            Destroy(gameObject);
            }
    }
}
