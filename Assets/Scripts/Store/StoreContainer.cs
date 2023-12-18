using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreContainer : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] public ItemVenta[] storeItems;

    [HideInInspector] public bool storeActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            storeActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            storeActive = false;
        }
    }
}
