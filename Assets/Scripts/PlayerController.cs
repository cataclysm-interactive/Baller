using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 15f;
    public Camera cam;
    public float thrust = 4f;
    public Rigidbody2D rb;
    public GameObject startMenu;
    public string nameOfEquippedSkin;
    public SpriteRenderer image;
    public GameObject finger;
    Touch touch;

    public static PlayerController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.simulateMouseWithTouches = true;
        string Skinname = PlayerPrefs.GetString("Skin");
        Cosmetic skin = CosmeticManager.instance.RetriveCosmetic(Skinname);
        image.sprite = skin.skinImage;

        string trailName = PlayerPrefs.GetString("Trail");
        Cosmetic trail = CosmeticManager.instance.RetriveCosmetic(trailName);
        GetComponent<TrailRenderer>().colorGradient = trail.trailGradient;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.instance.platform == RuntimePlatform.WindowsPlayer)
        {
            Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetDirection = target - transform.position.normalized;
            rb.AddForce((target - transform.position).normalized * thrust, ForceMode2D.Impulse);
        }

        if (GameManager.instance.platform == RuntimePlatform.WindowsEditor)
        {
            Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetDirection = target - transform.position.normalized;
            rb.AddForce((target - transform.position).normalized * thrust, ForceMode2D.Impulse);
        }

        if(Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            Vector3 target = cam.ScreenToWorldPoint(touch.position);
            Vector2 targetDirection = target - transform.position;
            rb.AddForce(targetDirection, ForceMode2D.Impulse);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    public void EquipSkin(Cosmetic cosmetic)
    {
        if(cosmetic.type == Cosmetic.TypeOfCosmetic.Skin)
        {
            PlayerPrefs.SetString("Skin", cosmetic.name);
            image.sprite = cosmetic.skinImage;
        }
        else if(cosmetic.type == Cosmetic.TypeOfCosmetic.Trail)
        {
            PlayerPrefs.SetString("Trail", cosmetic.name);
            GetComponent<TrailRenderer>().colorGradient = cosmetic.trailGradient;
        }

    }
}
