using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using Unity.RemoteConfig;

public class DeathCounter : MonoBehaviour , IUnityAdsListener
{
    public static DeathCounter instance;

    public int deaths;
    string indamiddleID = "video";
    string gameID = "3808217";
    int deathsBeforeAd;

    struct userAttributes { }
    struct appAttributes { }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;

        DontDestroyOnLoad(this);
        ConfigManager.FetchCompleted += UpdateConfig;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID);
    }

    void UpdateConfig(ConfigResponse response)
    {
        deathsBeforeAd = ConfigManager.appConfig.GetInt("scoreBeforeAds");
    }

    // Update is called once per frame
    void Update()
    {
        if(deaths >= deathsBeforeAd && deathsBeforeAd > 1)
        {
            WatchMiddleAd();
            deaths = 0;
        }
    }

    public void WatchMiddleAd()
    {
        if (Advertisement.IsReady(indamiddleID) && PlayerPrefs.GetInt("Ads") == 0)
        {
            Advertisement.Show(indamiddleID);
        }
    }

    public void OnUnityAdsDidError(string result)
    {

    }

    public void OnUnityAdsDidFinish(string result, ShowResult endResult)
    {

    }

    public void OnUnityAdsDidStart(string result)
    {

    }

    public void OnUnityAdsReady(string result)
    {

    }
}
