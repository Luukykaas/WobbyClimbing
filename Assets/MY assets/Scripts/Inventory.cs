using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int availableSlots = 20;
    public Sprite Empty;
    public Sprite SulphurSprite;
    public Sprite IronSprite;
    public Sprite CoalSprite;
    public Sprite CopperSprite;
    public Sprite FluoriteSprite;
    public Sprite DiamondsSprite;
    public Sprite JasperSprite;

    public GameObject[] slots =
    {

    };

    public int[] sameItems =
    {
        0,
        0,
        0,
        0
    };



    public void RecieveItem(string item)
    {
        int activeSlot = 0;

        for(int i = 0; i < slots.Length; i++)
        {
            for (int t = 0; t < slots.Length; t++)
            {
                if (slots[t].GetComponent<ItemHolder>().item == slots[i].GetComponent<ItemHolder>().item) sameItems[i]++;
            }
        }

        bool slotFound = false;

        for (int o = 0; o < slots.Length; o++)
        {
            if (item == slots[o].GetComponent<ItemHolder>().item)
            {
                slotFound = true;
                activeSlot = o;
            }
        }

        if(!slotFound)
        {
            activeSlot = 20 - availableSlots;
        }

        switch (item)
        {
            case "Sulphur":
                slots[activeSlot].GetComponent<Image>().sprite = SulphurSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Sulphur";
                slots[activeSlot].GetComponentInChildren<TMP_Text>().text = OreDection.instance.sulfurPublic.ToString();
                break;
            case "Iron":
                slots[activeSlot].GetComponent<Image>().sprite = IronSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Iron";
                slots[activeSlot].GetComponentInChildren<TMP_Text>().text = OreDection.instance.ironPublic.ToString();
                break;
            case "Copper":
                slots[activeSlot].GetComponent<Image>().sprite = CopperSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Copper";
                slots[activeSlot].GetComponentInChildren<TMP_Text>().text = OreDection.instance.copperPublic.ToString();
                break;
            case "Coal":
                slots[activeSlot].GetComponent<Image>().sprite = CoalSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Coal";
                slots[activeSlot].GetComponentInChildren<TMP_Text>().text = OreDection.instance.coalPublic.ToString();
                break;
            case "Fluorite":
                slots[activeSlot].GetComponent<Image>().sprite = FluoriteSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Fluorite";
                slots[activeSlot].GetComponentInChildren<TMP_Text>().text = OreDection.instance.fluoritePublic.ToString();
                break;
            case "Diamonds":
                slots[activeSlot].GetComponent<Image>().sprite = DiamondsSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Diamonds";
                slots[activeSlot].GetComponentInChildren<TMP_Text>().text = OreDection.instance.diamondPublic.ToString();
                break;
            case "Jasper":
                slots[activeSlot].GetComponent<Image>().sprite = JasperSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Jasper";
                break;


            default: slots[activeSlot].GetComponent<Image>().sprite = Empty; break;
        }

        if (availableSlots > 0 && !slotFound) availableSlots--;

    }

    public void DeleteItem(string item, int amount)
    {
        bool itemExists = false;
        int itemNumber = 0;

        for (int o = 0; o < slots.Length; o++)
        {
            if (item == slots[o].GetComponent<ItemHolder>().item)
            {
                itemExists = true;
                itemNumber = o;
            }
        }

        if (itemExists)
        {
            switch(item)
            {
                case "Sulphur":
                    if(amount == OreDection.instance.sulfurPublic)
                    {
                        slots[itemNumber].GetComponent<Image>().sprite = Empty;
                    }
                    break;
                case "Iron":
                    if (amount == OreDection.instance.ironPublic)
                    {
                        slots[itemNumber].GetComponent<Image>().sprite = Empty;
                    }
                    break;
                case "Copper":
                    if (amount == OreDection.instance.copperPublic)
                    {
                        slots[itemNumber].GetComponent<Image>().sprite = Empty;
                    }
                    break;
                case "Coal":
                    if (amount == OreDection.instance.coalPublic)
                    {
                        slots[itemNumber].GetComponent<Image>().sprite = Empty;
                    }
                    break;
                case "Fluorite":
                    if (amount == OreDection.instance.fluoritePublic)
                    {
                        slots[itemNumber].GetComponent<Image>().sprite = Empty;
                    }
                    break;
                case "Diamonds":
                    if (amount == OreDection.instance.diamondPublic)
                    {
                        slots[itemNumber].GetComponent<Image>().sprite = Empty;
                    }
                    break;

                default: 
                    break;
            }
        }
        else
        {

        }
    }
}
