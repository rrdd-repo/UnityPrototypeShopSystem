using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShop : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionsObj;
    [SerializeField]
    private GameObject _inventoryButton;


    // Opens up options menu and closes inventory button
    public void Options() {
        _optionsObj.SetActive(true);
        _inventoryButton.SetActive(false);
    }


    // Checks if player enters trigger, if so starts options menu and stops player from moving
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerMov playerMov = col.GetComponent<PlayerMov>();
            playerMov.canMove = false;
            Options();
        }
    }

}
