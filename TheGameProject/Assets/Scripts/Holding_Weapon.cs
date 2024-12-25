using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding_Weapon : MonoBehaviour
{
    [SerializeField] Sprite[] gameWeapons;
    Sprite currentWeapon;
    public string selectedWeapon = "Hand"; //Placeholder

    private void Update()
    {
        if (selectedWeapon == "Hand")
        {
            currentWeapon = gameWeapons[0];
        }
        else if (selectedWeapon == "Flint Pistol")
        {
            currentWeapon = gameWeapons[1];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = currentWeapon;

        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            selectedWeapon = "Flint Pistol";
        }
    }
}

