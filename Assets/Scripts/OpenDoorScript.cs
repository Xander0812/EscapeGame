using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    //Маленький скрипт открытия двери с использованием ключа.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.SetActive(false);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
