using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplayerManager : MonoBehaviour
{
    public static MultiplayerManager instance;
    public Transform startingObsticle;
    public GameObject[] obsticles;
    public TextMeshProUGUI coinsDisplay;
    public TextMeshProUGUI display;

    int coins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

        coins = PlayerPrefs.GetInt("Coins");
        coinsDisplay.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    }

    public void Increase()
    {
        Debug.Log("Click");
        display.text = (int.Parse(display.text) + 10).ToString();

        if (int.Parse(display.text) > coins)
        {
            display.text = (int.Parse(display.text) - 10).ToString();
        }
    }

    public void Decrease()
    {
        Debug.Log("Click");
        display.text = (int.Parse(display.text) - 10).ToString();
        if (int.Parse(display.text) <= 0)
        {
            display.text = (int.Parse(display.text) + 10).ToString();
        }
    }

    public void StartChallenge()
    {
        Debug.Log("Click");
        ClientSend.Matchmake(int.Parse(display.text));
    }
}
