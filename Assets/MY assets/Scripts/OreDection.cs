using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using TMPro;
using System.Runtime.CompilerServices;
using System.Data.SqlTypes;
using Unity.VisualScripting;



public class OreDection : MonoBehaviour
{
    public double money;
    public double sulfur = 0;
    public int sulfurAlt = 0;
    public int sulfurPublic = 0;
    public double iron = 0;
    public int ironAlt = 0;
    public int ironPublic = 0;
    public double copper = 0;
    public int copperAlt = 0;
    public int copperPublic = 0;
    public double coal = 0;
    public int coalAlt = 0;
    public int coalPublic = 0;
    public double fluorite = 0;
    public int fluoriteAlt = 0;
    public int fluoritePublic = 0;
    public double diamond = 0;
    public int diamondAlt = 0;
    public int diamondPublic = 0;
    public bool helmet = false;
    public bool chestplate = false;
    public bool pants = false;
    public bool boots = false;
    public bool pickaxe = false;
    public bool sword = false;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI sulfurText;
    public TextMeshProUGUI ironText;
    public TextMeshProUGUI copperText;
    public TextMeshProUGUI coalText;
    public TextMeshProUGUI fluoriteText;
    MOvment Movement;
    Inventory invent;
    public GameObject Inventory;
    public GameObject Audio;
    AudioSource AudioScript;
    Animator anim;
    public static OreDection instance;

    private void Awake()
    {
        if (OreDection.instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Movement = gameObject.GetComponent<MOvment>();
        AudioScript = Audio.GetComponent<AudioSource>();
        invent = Inventory.GetComponent<Inventory>();
    }

    private void Update()
    {
        if (sulfurAlt != sulfurPublic)
        {
            sulfurAlt = sulfurPublic;
            invent.RecieveItem("Sulphur");
        }
        if (ironAlt != ironPublic)
        {
            invent.RecieveItem("Iron");
            ironAlt = ironPublic;
        }
        if (copperAlt != copperPublic)
        {
            invent.RecieveItem("Copper");
            copperAlt = copperPublic;
        }
        if (coalAlt != coalPublic)
        {
            invent.RecieveItem("Coal");
            coalAlt = coalPublic;
        }
        if (fluoriteAlt != fluoritePublic)
        {
            invent.RecieveItem("Fluorite");
            fluoriteAlt = fluoritePublic;
        }
        if (diamondAlt != diamondPublic)
        {
            invent.RecieveItem("Diamonds");
            diamondAlt = diamondPublic;
        }
    }

    public void Artifact(int number)
    {
        switch (number)
        {
            case 1:
                money += 15.00;
                break;
            case 2:
                money += 30.00;
                break;


            default: break;
        }
    }

    public void GiveItem()
    {
        sulfurPublic++;
        sulfur++;
    }

    public void Sell(String ore)
    {
        Debug.Log("Selling: " + ore);

        switch (ore)
        {
            case "SULFUR":
                if (sulfurPublic > 0)
                {
                    sulfurPublic -= 1;
                    sulfur -= 1.0f;
                    money += 0.50f;
                    AudioScript.clip = AudioSources.instance.Sell;
                    AudioScript.Play();
                }
                break;

            case "IRON":
                if (ironPublic > 0)
                {
                    ironPublic -= 1;
                    iron -= 1.0f;
                    money += 0.40f;
                    AudioScript.clip = AudioSources.instance.Sell;
                    AudioScript.Play();
                }
                break;

            case "COPPER":
                if (copperPublic > 0)
                {
                    copperPublic -= 1;
                    copper -= 1.0f;
                    money += 0.37f;
                    AudioScript.clip = AudioSources.instance.Sell;
                    AudioScript.Play();
                }
                break;

            case "COAL":
                if (coalPublic > 0)
                {
                    coalPublic -= 1;
                    coal -= 1.0f;
                    money += 0.63f;
                    AudioScript.clip = AudioSources.instance.Sell;
                    AudioScript.Play();
                }
                break;

            case "FLUORITE":
                if (fluoritePublic > 0)
                {
                    fluoritePublic -= 1;
                    fluorite -= 1.0f;
                    money++;
                    AudioScript.clip = AudioSources.instance.Sell;
                    AudioScript.Play();
                }
                break;

            default: break;
        }
    }

    public void Buy(String item)
    {
        Debug.Log("Buying: " + item);

        switch (item)
        {
            case "HELMET":
                if (money >= 20 && !helmet)
                {
                    helmet = true;
                    money -= 20;
                    AudioScript.clip = AudioSources.instance.Buy;
                    AudioScript.Play();
                }
                break;

            case "CHESTPLATE":
                if (money >= 50 && !chestplate)
                {
                    chestplate = true;
                    money -= 50;
                    AudioScript.clip = AudioSources.instance.Buy;
                    AudioScript.Play();
                }
                break;

            case "PANTS":
                if (money >= 30 && !pants)
                {
                    pants = true;
                    money -= 30;
                    AudioScript.clip = AudioSources.instance.Buy;
                    AudioScript.Play();
                }
                break;

            case "BOOTS":
                if (money >= 1 && !boots)
                {
                    boots = true;
                    money -= 20;
                    AudioScript.clip = AudioSources.instance.Buy;
                    AudioScript.Play();
                }
                break;

            case "PICKAXE":
                if (money >= 20 && !pickaxe)
                {
                    pickaxe = true;
                    money -= 20;
                    AudioScript.clip = AudioSources.instance.Buy;
                    AudioScript.Play();
                }
                break;

            case "SWORD":
                if (money >= 20 && !sword)
                {
                    sword = true;
                    money -= 20;
                    AudioScript.clip = AudioSources.instance.Buy;
                    AudioScript.Play();
                }
                break;

            default: break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Sulfur"))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                sulfur += 0.02;
                sulfurPublic = (int)Math.Round(sulfur);
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Iron"))
        {

            if (Input.GetKeyDown(KeyCode.M))
            {
                iron += 0.03;
                ironPublic = (int)Math.Round(iron);
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Copper"))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                copper += 0.02;
                copperPublic = (int)Math.Round(copper);
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Coal"))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                coal += 0.015;
                coalPublic = (int)Math.Round(coal);
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Fluorite"))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                fluorite += 0.01;
                fluoritePublic = (int)Math.Round(fluorite);
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Diamond"))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                diamond += 0.005;
                diamondPublic = (int)Math.Round(diamond);
                anim.SetBool("Mining", true);
            }
        }
    }
}
