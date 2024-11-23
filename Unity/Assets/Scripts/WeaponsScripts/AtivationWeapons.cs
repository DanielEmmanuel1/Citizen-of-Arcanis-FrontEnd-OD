using DevionGames.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationSword : MonoBehaviour
{
    public Item weaponData;
    public int weaponNumber; // Número de la espada que este objeto representa
    private CollectionWeapons collectionWeapons;

    bool canPick = false;
    Collider player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPick = true;
            player = other;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            PickWeapon();
        }
    }

    void PickWeapon()
    {
        if (!canPick) return;

        // Intentar obtener CollectionWeapons en el momento de la colisión
        CollectionWeapons collectionWeapons = player.GetComponentInChildren<CollectionWeapons>();

        if (collectionWeapons == null)
        {
            Debug.LogError("CollectionWeapons component not found on the Player or its children.");
            return; // Salir del método si CollectionWeapons es nulo
        }

        // Activar el arma correspondiente
        collectionWeapons.ActivationWeapon(weaponNumber);
        Debug.Log($"Weapon {weaponNumber} activated.");

        // Destruir el objeto que representa la espada en el suelo
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPick = false;
            //player = other;
        }
    }
}
