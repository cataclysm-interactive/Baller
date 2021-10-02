using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Cosmetic : ScriptableObject
{
    /// <summary>
    /// This scriptable object is a system that allows creation of new cosmetics a breeze. Make a new object, fill in the data and put into CosmeticManage.cs
    /// </summary>

    public enum TypeOfCosmetic { Skin, Trail, Scene };
    public TypeOfCosmetic type;

    //REQUIRED FOR EVERY COSMETIC
    public string cosmeticName;
    public int price;

    //REQUIRED FOR SKINS

    public Sprite skinImage;

    //REQUIRED FOR TRAILS

    public Gradient trailGradient;

    //REQUIRED FOR SCENES

    public Color sceneBackground;
    public Color sceneWalls;
    public Color sceneObsticles;
}
