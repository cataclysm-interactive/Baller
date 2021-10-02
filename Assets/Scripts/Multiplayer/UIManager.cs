using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject loadingScreen;

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
        SceneManager.LoadScene(0);
    }

    /// <summary>Attempts to connect to the server.</summary>
    public void Start()
    {
        Client.instance.ConnectToServer();
    }
}
