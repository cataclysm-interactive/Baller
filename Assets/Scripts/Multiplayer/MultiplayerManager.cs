using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiplayerManager : MonoBehaviour
{
    public static MultiplayerManager instance;
    public GameObject[] obsticles;
    public Transform startObject;
    public GameObject player;
    public int score;
    public GameObject startMenu;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI coinsDisplay;
    public TextMeshProUGUI display;
    public GameObject button;
    public GameObject text;
    public GameObject loading;
    public GameObject noOthers;

    int coins;
    bool matched;
    int match;

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
        targetPos = startObject.position;
    }

    public void Update()
    {
        if(score > 0)
        {
            scoreDisplay.text = score.ToString();
        }

        if(player.activeSelf == false && matched == true)
        {
            ClientSend.FinishedMatch(score, match);
        }
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

    public void MatchFound(int match)
    {
        
        StartCoroutine(Generator());
        player.SetActive(true);
        startMenu.SetActive(false);
        matched = true;

    }

    public void NoMatch()
    {
        button.GetComponent<Button>().interactable = true;
        text.SetActive(true);
        noOthers.SetActive(true);
        loading.SetActive(false);
    }

    Vector3 targetPos;

    IEnumerator Generator()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(0.5f);

            targetPos.y = targetPos.y + 6;

            int selectedObsticle = Random.Range(0, obsticles.Length);

            Instantiate(obsticles[selectedObsticle], targetPos, startObject.rotation);
        }
    }

}
