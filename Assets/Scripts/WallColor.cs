using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColor : MonoBehaviour
{
    public SpriteRenderer wall1;
    public SpriteRenderer wall2;
    public SpriteRenderer wall3;
    public SpriteRenderer background;

    string skin;

    public void Update()
    {
        skin = PlayerPrefs.GetString("Scene");
        if (skin != null)
        {
            Cosmetic cos = CosmeticManager.instance.RetriveCosmetic(skin);
            if(cos != null)
            {
                wall1.color = cos.sceneWalls;
                wall2.color = cos.sceneWalls;
                wall3.color = cos.sceneWalls;
                background.color = cos.sceneBackground;
            }
        }
    }
}
