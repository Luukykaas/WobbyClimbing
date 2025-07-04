using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject death;
    [SerializeField] GameObject QuitShop;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Shoppanel;
    [SerializeField] GameObject Sellpanel;
    public bool ShopActive;
    public bool freez;
    public GameObject Player;
    public GameObject Cam;
    public float pLerp = .02f;
    public Transform shopPos;
    CameraCon camcon;
    Animator anim;
    MOvment Movement;
    public Transform spawn;

    private void Awake()
    {
        if (UIManager.instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
       camcon = Cam.GetComponent<CameraCon>();
       anim = Player.GetComponent<Animator>();
       Movement = Player.GetComponent<MOvment>();
    }

    public void ToggleDeath()
    {
        death.SetActive(!death.activeSelf);
    }

    public void ChangeShopActive(bool active)
    {
        ShopActive = active;
    }

    public void ChangeUIByGO(GameObject GO)
    {
        if (GO != null) GO.SetActive(!GO.activeSelf);
    }

    public void Freeze(bool freeze)
    {
        freez = freeze;
        if (freeze) Time.timeScale = 0;
        else Time.timeScale = 1;

    }

    public void ToggleShop()
    {
        QuitShop.SetActive(true);
        Shop.SetActive(false);
        Shoppanel.SetActive(true);
    }
    public void UnToggleShop()
    {
        QuitShop.SetActive(false);
        Shop.SetActive(true);
        Shoppanel.SetActive(false);
    }
    
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
