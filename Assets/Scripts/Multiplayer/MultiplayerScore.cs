using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerScore : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MultiplayerManager.instance.score = MultiplayerManager.instance.score + 1;

            this.gameObject.SetActive(false);
        }
    }
}
