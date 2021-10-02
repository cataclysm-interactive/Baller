using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void AcheivmentsMenu()
    {
        Social.ShowAchievementsUI();
    }

    public void LeaderboardMenu()
    {
        Social.ShowLeaderboardUI();
    }

    public void LoadMultiplayer()
    {
        SceneManager.LoadScene(1);
    }
}
