using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour /* Скрипт для конца уровня и выхова меню перехода на следующий уровень */
{
    public GameObject Endscrn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerTag")
        {
            Endscrn.gameObject.SetActive(true);
        }
    }
}
