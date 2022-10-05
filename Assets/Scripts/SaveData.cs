using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static void Save()
    {
        PlayerPrefs.SetInt("Coins", Systems.coins + GetCoins());
        PlayerPrefs.SetInt("High_Score", Systems.score);
        PlayerPrefs.Save();
    }

    private static int GetCoins()
    {
        int i = 0;
        if (PlayerPrefs.HasKey("Coins"))
        {
            i = PlayerPrefs.GetInt("Coins");
        }
        return i;
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("Coins"))
        {
            Systems.coins = PlayerPrefs.GetInt("Coins");
        }
        if (PlayerPrefs.HasKey("High_Score"))
        {
            Systems.score = PlayerPrefs.GetInt("High_Score");
        }
    }
}
