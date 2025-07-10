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
                break;
            case "Iron":
                slots[activeSlot].GetComponent<Image>().sprite = IronSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Iron";
                break;
            case "Copper":
                slots[activeSlot].GetComponent<Image>().sprite = CopperSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Copper";
                break;
            case "Coal":
                slots[activeSlot].GetComponent<Image>().sprite = CoalSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Coal";
                break;
            case "Fluorite":
                slots[activeSlot].GetComponent<Image>().sprite = FluoriteSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Fluorite";
                break;
            case "Diamonds":
                slots[activeSlot].GetComponent<Image>().sprite = DiamondsSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Diamonds";
                break;
            case "Jasper":
                slots[activeSlot].GetComponent<Image>().sprite = JasperSprite;
                slots[activeSlot].GetComponent<ItemHolder>().item = "Jasper";
                break;


            default: slots[activeSlot].GetComponent<Image>().sprite = Empty; break;
        }

        if (availableSlots > 0) availableSlots--;

    }
}
