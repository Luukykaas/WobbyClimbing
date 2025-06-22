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
    public int sulfurPublic = 0;
    public double iron = 0;
    public int ironPublic = 0;
    public double copper = 0;
    public int copperPublic = 0;
    public double coal = 0;
    public int coalPublic = 0;
    public double fluorite = 0;
    public int fluoritePublic = 0;
    public double diamond = 0;
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
    }

    private void Update()
    {
        moneyText.text = "Money: " + money.ToString();
        sulfurText.text = "Sulfur: " + sulfurPublic.ToString();
        ironText.text = "Iron: " + ironPublic.ToString();
        copperText.text = "Copper: " + copperPublic.ToString();
        coalText.text = "Coal: " + coalPublic.ToString();
        fluoriteText.text = "Fluorite: " + fluoritePublic.ToString();
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
            sulfur += 0.02;
            sulfurPublic = (int)Math.Round(sulfur);
            sulfurText.text = "Sulfur: " + sulfurPublic.ToString();
            if (Input.GetKeyDown(KeyCode.M))
            {
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Iron"))
        {
            iron += 0.03;
            ironPublic = (int)Math.Round(iron);
            ironText.text = "Iron: " + ironPublic.ToString();
            if (Input.GetKeyDown(KeyCode.M))
            {
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Copper"))
        {
            copper += 0.02;
            copperPublic = (int)Math.Round(copper);
            copperText.text = "Copper: " + copperPublic.ToString();
            if (Input.GetKeyDown(KeyCode.M))
            {
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Coal"))
        {
            coal += 0.015;
            coalPublic = (int)Math.Round(coal);
            coalText.text = "Coal: " + coalPublic.ToString();
            if (Input.GetKeyDown(KeyCode.M))
            {
                anim.SetBool("Mining", true);
            }
        }
        if (other.gameObject.CompareTag("Fluorite"))
        {
            fluorite += 0.01;
            fluoritePublic = (int)Math.Round(fluorite);
            fluoriteText.text = "Fluorite: " + fluoritePublic.ToString();
            if (Input.GetKeyDown(KeyCode.M))
            {
                anim.SetBool("Mining", true);
            }
        }
    }
}
