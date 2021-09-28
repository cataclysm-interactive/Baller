using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CosmeticManager : MonoBehaviour
{
    public Cosmetic[] cosmetics;
    public GameObject cosmeticButtonPrefab;
    public Transform skinMenuContent;
    public Transform trailMenuContent;
    public TextMeshProUGUI coinText;


    public static CosmeticManager instance;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        foreach(Cosmetic cosmetic in cosmetics)
        {
            if(cosmetic.type == Cosmetic.TypeOfCosmetic.Skin)
            {
                CosmeticObject thing = Instantiate(cosmeticButtonPrefab, skinMenuContent).GetComponent<CosmeticObject>();
                thing.DisplayCosmetic(cosmetic);
            }
            else if(cosmetic.type == Cosmetic.TypeOfCosmetic.Trail)
            {
                CosmeticObject thing = Instantiate(cosmeticButtonPrefab, trailMenuContent).GetComponent<CosmeticObject>();
                thing.DisplayCosmetic(cosmetic);
            }
        }
    }

    private void Update()
    {
        coinText.text = GameManager.instance.coins.ToString();
    }

    public Cosmetic RetriveCosmetic(string name)
    {
        foreach(Cosmetic cosmetic in cosmetics)
        {
            Debug.LogWarning(cosmetic.name);

            if(cosmetic.name == name)
            {
                return cosmetic;
            }
        }
        return null;
    }
}
