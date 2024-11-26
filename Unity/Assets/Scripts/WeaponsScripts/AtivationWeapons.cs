using DevionGames.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the activation of weapons when the player collects them in the game world.
/// This script should be attached to weapon pickup objects in the scene.
/// </summary>
public class ActivationSword : MonoBehaviour
{
    public Item weaponData;
    bool canPick = false;
    Collider player;

    /// <summary>
    /// Identifier number for the weapon this object represents.
    /// This number should match the weapon index in the CollectionWeapons component.
    /// </summary>
    public int weaponNumber;
    /// <summary>
    /// Reference to the CollectionWeapons component that manages the player's weapon inventory.
    /// </summary>
    private CollectionWeapons collectionWeapons;
   
    /// <summary>
    /// Handles the collision between the player and the weapon pickup object.
    /// When triggered, activates the corresponding weapon in the player's inventory
    /// and destroys the pickup object.
    /// </summary>
    /// <param name="other">The Collider that entered this object's trigger zone</param>

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

        CollectionWeapons collectionWeapons = player.GetComponentInChildren<CollectionWeapons>();

        if (collectionWeapons == null)
        {
            Debug.LogError("CollectionWeapons component not found on the Player or its children.");
            return;
        }

        collectionWeapons.ActivationWeapon(weaponNumber);
        Debug.Log($"Weapon {weaponNumber} activated.");

        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPick = false;
        }
    }
}
