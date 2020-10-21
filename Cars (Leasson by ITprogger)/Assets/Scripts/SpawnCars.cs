using UnityEngine;
using System.Collections;
public class SpawnCars : MonoBehaviour
{

    public GameObject [] cars;
    private float[] positions = {-1.89f, -0.66f, 0.65f, 1.93f};

    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
    while(true)
        {
            Instantiate(
                cars[Random.Range(0, cars.Length)],
                new Vector3(positions[Random.Range(0, 4)], 15f, 1.85f),
                Quaternion.Euler(new Vector3(90, 180, 0))
            );
            yield return new WaitForSeconds(2.5f);
        }
    }

}
