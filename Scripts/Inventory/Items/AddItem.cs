using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private Item inventarioItem;
    [SerializeField] private int cantidadtoAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Inventory.Instance.AddItem(inventarioItem, cantidadtoAdd);
            Destroy(gameObject);
        }
    }

}
