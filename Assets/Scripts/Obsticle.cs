using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public void Awake()
    {
        Cosmetic cos = CosmeticManager.instance.RetriveCosmetic(PlayerPrefs.GetString("Scene"));
        if(cos != null)
        {
            GetComponent<SpriteRenderer>().color = cos.sceneObsticles;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
