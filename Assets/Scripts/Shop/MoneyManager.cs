using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public float coins;
    public TMP_Text coinUI;

    public void AddCoins(float cash)
    {
        // Adds coins
        coins += cash;
        coinUI.text = coins.ToString();
    }

    public bool RemoveCoins(float cash)
    {
        // Checks if you can buy the item
        // The coins > 0 is not even required but I included it
        // there just to make sure we don't go to negatives
        if (coins >= cash && coins > 0)
        {
            coins -= cash;
            coinUI.text = coins.ToString();
            return true;
        }

        return false;
    }
}
