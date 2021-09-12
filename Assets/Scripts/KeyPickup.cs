using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    //Это скрипт на подбор ключа на 3 уровне

    [SerializeField] private GameObject keyHole;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            this.gameObject.SetActive(false);
            keyHole.SetActive(false);
        }
    }
}
