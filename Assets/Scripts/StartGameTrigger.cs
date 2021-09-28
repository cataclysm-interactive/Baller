using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameTrigger : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject finger;
    public GameObject buttonA;
    public GameObject buttonB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            startMenu.SetActive(false);
            finger.SetActive(false);
            buttonA.SetActive(false);
            buttonB.SetActive(false);
        }
    }
}
