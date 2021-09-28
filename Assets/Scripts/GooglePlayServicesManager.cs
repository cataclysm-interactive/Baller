using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
//using GooglePlayGames.BasicApi;
//using GooglePlayGames;

public class GooglePlayServicesManager : MonoBehaviour
{
    static GooglePlayServicesManager instance;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        //PlayGamesClientConfiguration client = new PlayGamesClientConfiguration.Builder().Build();
        //PlayGamesPlatform.InitializeInstance(client);
        //PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((result) =>
        {
            Debug.Log(result);
        });
    }


    ///Todo
    ///
    ///Add save game system, achevements,leaderboards.
}
