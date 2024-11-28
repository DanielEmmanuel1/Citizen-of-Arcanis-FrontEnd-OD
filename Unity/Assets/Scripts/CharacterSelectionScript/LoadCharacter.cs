using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using DevionGames.InventorySystem;

/// <summary>
/// Handles the loading and instantiation of character prefabs based on player selection.
/// This script is used in game scenes where the selected character needs to be spawned.
/// It reads the player's character selection from PlayerPrefs and instantiates the corresponding prefab.
/// </summary>
public class LoadCharacter : MonoBehaviour
{

    public static LoadCharacter Instance;
    /// <summary>
    /// Array of character prefabs that can be instantiated.
    /// These should be assigned in the Unity Inspector.
    /// </summary>
    public GameObject[] characterPrefab;
    /// <summary>
    /// Transform reference for the position where the character will be spawned.
    /// Should be set in the Unity Inspector.
    /// </summary>
    public Transform spawnPoint;
    /// <summary>
    /// TextMeshPro UI component to display the selected character's name.
    /// Optional - can be left unassigned if character name display is not needed.
    /// </summary>
    public TMP_Text label;
    
    public GameObject mainCharacter;

    /// <summary>
    /// Initializes the character loading process when the script starts.
    /// Retrieves the selected character index from PlayerPrefs and instantiates the corresponding prefab.
    /// Also updates the character name label if one is assigned.
    /// </summary>
    void Start() // Corrige aquí el error de "Star"
    {
        // Obtén el índice del personaje seleccionado guardado en PlayerPrefs
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0); // Usa 0 como valor predeterminado
        if (selectedCharacter < 0 || selectedCharacter >= characterPrefab.Length)
        {
            Debug.LogError("Selected character index is out of range. Check the assigned prefabs in the inspector");
            return;
        }

        GameObject prefab = characterPrefab[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        mainCharacter = clone;
        
        if (label != null)
        {
            label.text = prefab.name;
        }
    }

    public void LoadWeapon()
    {
        CollectionWeapons collectionWeapons = mainCharacter.GetComponentInChildren<CollectionWeapons>();
        collectionWeapons.ActivationWeapon(ItemContainer.Instance.currentWeaponPrefab.GetComponent<ActivationSword>().weaponNumber, false);
    }
}
