using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinButton : MonoBehaviour
{
    //public enum SkinToBuy { Pentagon, Gradient, Hoonigan, Golden };
    //public SkinToBuy skinToBuy;
    //public Skin skin;
    //public Image skinImage;
    //public TextMeshProUGUI buttonText;
    //public TextMeshProUGUI skinText;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    skinText.text = skin.nameOfSkin;
    //    skinImage.sprite = skin.skinImage;

    //    switch (skinToBuy)
    //    {
    //        case SkinToBuy.Pentagon:
    //            if (PlayerPrefs.GetInt("Pentagon") == 1)
    //                buttonText.text = "Equip";
    //            else if (PlayerPrefs.GetInt("Pentagon") == 0)
    //                buttonText.text = "Buy";
    //            break;

    //        case SkinToBuy.Gradient:
    //            if (PlayerPrefs.GetInt("Gradient") == 1)
    //                buttonText.text = "Equip";
    //            else if (PlayerPrefs.GetInt("Gradient") == 0)
    //                buttonText.text = "Buy";
    //            break;

    //        case SkinToBuy.Hoonigan:
    //            if (PlayerPrefs.GetInt("Hoonigan") == 1)
    //                buttonText.text = "Equip";
    //            else if (PlayerPrefs.GetInt("Hoonigan") == 0)
    //                buttonText.text = "Buy";
    //            break;

    //        case SkinToBuy.Golden:
    //            //do nothing lol
    //            break;
    //    }
    //}
    
    //public void ButtonClick()
    //{
    //    Debug.Log("Button Clicked");

    //    switch (skinToBuy)
    //    {
    //        case SkinToBuy.Pentagon:
    //            CosmeticManager.instance.PentagonSkinEquip(skin);
    //            break;

    //        case SkinToBuy.Gradient:
    //            CosmeticManager.instance.GradientSkinEquip(skin);
    //            break;

    //        case SkinToBuy.Hoonigan:
    //            CosmeticManager.instance.HooniganSkinEquip(skin);
    //            break;
    //        case SkinToBuy.Golden:
    //            CosmeticManager.instance.GoldenSkinEquip(skin);
    //            break;
    //    }
    //}
}
