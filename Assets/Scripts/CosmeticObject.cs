﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.AppCenter.Unity.Analytics;

public class CosmeticObject : MonoBehaviour
{
    public GameObject skin;
    public GameObject trail;
    public GameObject scene;
    public RawImage wall;
    public RawImage background;
    public RawImage obsticles;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI buttonText;


    public Image skinImage;

    Cosmetic assignedCosmetic;

    public void DisplayCosmetic(Cosmetic cosmetic)
    {
        assignedCosmetic = cosmetic;

        switch (cosmetic.type)
        {
            case Cosmetic.TypeOfCosmetic.Skin:
                nameText.text = cosmetic.cosmeticName;
                if(PlayerPrefs.GetInt(assignedCosmetic.name) == 1)
                {
                    buttonText.text = "Equip";
                }
                else
                {
                    buttonText.text = cosmetic.price.ToString();
                }
                skinImage.sprite = cosmetic.skinImage;

                skin.SetActive(true);
                trail.SetActive(false);
                scene.SetActive(false);
                break;

            case Cosmetic.TypeOfCosmetic.Trail:
                nameText.text = cosmetic.cosmeticName;
                if (PlayerPrefs.GetInt(assignedCosmetic.name) == 1)
                {
                    buttonText.text = "Equip";
                }
                else
                {
                    buttonText.text = cosmetic.price.ToString();
                }
                skinImage.sprite = cosmetic.skinImage;

                skin.SetActive(false);
                trail.SetActive(true);
                scene.SetActive(false);
                break;

            case Cosmetic.TypeOfCosmetic.Scene:
                nameText.text = cosmetic.cosmeticName;
                if (PlayerPrefs.GetInt(assignedCosmetic.name) == 1)
                {
                    buttonText.text = "Equip";
                }
                else
                {
                    buttonText.text = cosmetic.price.ToString();
                }
                wall.color = cosmetic.sceneWalls;
                background.color = cosmetic.sceneBackground;
                obsticles.color = cosmetic.sceneObsticles;

                skin.SetActive(false);
                trail.SetActive(false);
                scene.SetActive(true);
                break;
        }
    }

    public void GetCosmetic()
    {
        if(PlayerPrefs.GetInt(assignedCosmetic.name) == 0 && GameManager.instance.coins >= assignedCosmetic.price)
        {
            PlayerPrefs.SetInt(assignedCosmetic.name, 1);
            GameManager.instance.coins -= assignedCosmetic.price;
            Analytics.TrackEvent("Purchased Cosmetic: " + assignedCosmetic.cosmeticName);
            buttonText.text = "Equip";
        }
        if(PlayerPrefs.GetInt(assignedCosmetic.name) == 1)
        {
            PlayerController.instance.EquipSkin(assignedCosmetic);
        }

    }
}
