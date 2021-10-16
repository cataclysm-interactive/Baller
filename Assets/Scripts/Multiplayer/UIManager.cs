using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject loadingScreen;
    public bool testMode;
    public TMP_InputField IP;
    public GameObject connectButton;

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
    }

    public void HideLoadingScreen()
    {
        loadingScreen.SetActive(false);
    }

    public void GoBack()
    {
        Client.instance.Disconnect();
        SceneManager.LoadScene(0);
    }

    /// <summary>Attempts to connect to the server.</summary>
    public void Start()
    {
        if(testMode == true)
        {
            IP.gameObject.SetActive(true);
            connectButton.SetActive(true);
        }
        else
        {
            Client.instance.ConnectToServer();
        }
    }

    public void ConnectToServer()
    {
        Client.instance.ip = IP.text;
        Client.instance.ConnectToServer();
    }
}
