using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour , IUnityAdsListener
{
    public static GameManager instance;

    public int score;
    public RuntimePlatform platform;
    public Transform startObject;
    public GameObject[] obsticles;
    public TextMeshProUGUI scoreText;
    public GameObject player;
    public GameObject deathScreen;
    public GameObject storeScreen;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI highScoreText;
    public int coins;
    public bool testMode;
    
    public int HighScore;
    Vector2 targetPos;

    string gameID = "3808217";
    string placementID = "freeCoins";
    string indamiddleID = "video";

    #region GameManager
    private void Awake()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID);
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        HighScore = PlayerPrefs.GetInt("HighScore");
        platform = Application.platform;
        deathScreen.SetActive(false);
        targetPos = startObject.position;
        StartCoroutine(Generator());
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score: " + HighScore;

        if(score > 0)
        {
            scoreText.text = score.ToString();
        }

        if (player.activeSelf == false && deathScreen.activeSelf == false && storeScreen.activeSelf == false)
        {
            moneyText.text = score.ToString();

            deathScreen.SetActive(true);

            if(score > HighScore)
            {
                HighScore = score;
                PlayerPrefs.SetInt("HighScore", score);
                PlayerPrefs.Save();
                if(score > 25)
                {
                    Social.ReportScore(score, GPGSIds.leaderboard_high_score, (bool result) =>
                    {
                        if (result == true)
                        {
                            Debug.Log("Leaderboard Updated");
                        }
                        else if (result == false)
                        {
                            Debug.Log("Error Lol");
                        }
                    });
                }
            }

            if(HighScore >= 10)
            {
                Social.ReportProgress(GPGSIds.achievement_10_points, 100.0f, result =>
                  {
                      if(result == true)
                      {
                          Debug.Log("10 Points Sucess");
                      }
                  });
            }
            if(HighScore >= 25)
            {
                WatchMiddleAd();
            }
            if(HighScore >= 50)
            {


                Social.ReportProgress(GPGSIds.achievement_50_points, 100.0f, result =>
                {
                    if (result == true)
                    {
                        Debug.Log("50 Points Sucess");
                    }
                });
            }
            if(HighScore >= 100)
            {
                Social.ReportProgress(GPGSIds.achievement_100_points, 100.0f, result =>
                {
                    if (result == true)
                    {
                        Debug.Log("100 Points Sucess");
                    }
                });
            }
            if(HighScore >= 200)
            {
                Social.ReportProgress(GPGSIds.achievement_200_score, 200.0f, result =>
                {
                    if (result == true)
                    {
                        Debug.Log("200 Points Sucess");
                    }
                });
            }

            coins = coins + score;

            Social.ReportScore(coins, GPGSIds.leaderboard_coins, result =>
            {
            });
        }

        PlayerPrefs.SetInt("Coins", coins);


    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    IEnumerator Generator()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(0.5f);


            targetPos.y = targetPos.y + 6;

            int selectedObsticle = Random.Range(0, obsticles.Length);

            Instantiate(obsticles[selectedObsticle], targetPos, startObject.rotation);

            //Debug.Log("Spawned Obsticle");
        }
    }

    #endregion

    #region Ads

    public void WatchMiddleAd()
    {
        if(Advertisement.IsReady(indamiddleID))
        {
            Advertisement.Show(indamiddleID);
        }
    }

    public void WatchRewardedAd()
    {
        if(Advertisement.IsReady(placementID))
        {
            Advertisement.Show(placementID);
        }
    }

    public void OnUnityAdsDidError(string result)
    {

    }

    public void OnUnityAdsDidFinish(string result,ShowResult endResult)
    {
        if(endResult == ShowResult.Finished)
        {
            coins = coins + 100;

            PlayerPrefs.SetInt("Coins", coins);
        }
    }

    public void OnUnityAdsDidStart(string result)
    {

    }

    public void OnUnityAdsReady(string result)
    {

    }

    #endregion


    public void CoinsPurchaseComplete()
    {
        coins += 500;
        PlayerPrefs.SetInt("Coins", coins);
    }
}
