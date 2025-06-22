using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Dialoge : MonoBehaviour
{
    public GameObject DialogePanel;
    public GameObject Player;
    public TextMeshProUGUI DialogeText;
    public TextMeshProUGUI ResponseText;
    public bool ok = false;
    public bool firstConversation = true;
    public bool conversionStarted = false;
    public int txtProgress = 0;
    public int end = 0;
    public string[] merchantTxt =
    {
        "Hey, what are you up to?",
        "You want to go to the next biome? I have a key for the door.",
        "I will give it to you if you give me 2 diamonds.",
        "Have you got the diamonds?",
        "Thanks! Here is the key..."
    };

    public string[] responseTxt =
    {
        "Bye!",
        "OK",
        "I want to go to the next biome",
        "Can I get it?",
        "OK",
        "Here",
        "Bye!"
    };

    public void Say()
    {
        DialogePanel.SetActive(true);

        if (!conversionStarted)
        {
            if (firstConversation)
            {
                txtProgress = 0;
            }
            else
            {
                txtProgress = 3;
            }
            if (OreDection.instance.diamondPublic < 2)
            {
                responseTxt[5] = "No";
                end = merchantTxt.Length-1;
            }
            else
            {
                responseTxt[5] = "Here";
                end = merchantTxt.Length;
            }
            conversionStarted = true;
        }

       
        if (txtProgress < end)
        {
            DialogeText.text = merchantTxt[txtProgress];
            ResponseText.text = responseTxt[txtProgress + 2];
        }
        else
        {
            DialogePanel.SetActive(false);
            txtProgress = 0;
            conversionStarted = false;
            UIManager.instance.Freeze(false);
        }




        /*
        if(oreDection.diamondPublic < 2)
        {
            if (txtProgress != 3)
            {
                DialogeText.text = merchantTxt[txtProgress];
                ResponseText.text = responseTxt[txtProgress + 2];
            }
            else
            {
                DialogePanel.SetActive(false);
                txtProgress = 0;
            }
        }
        else
        {
            txtProgress = 3;
            if (txtProgress < merchantTxt.Length)
            {
                DialogeText.text = merchantTxt[txtProgress];
                ResponseText.text = responseTxt[txtProgress + 2];
            }
            else
            {
                DialogePanel.SetActive(false);
                txtProgress = 0;
            }
        }
        */
    }

    public void OK()
    {
        txtProgress++;
    }
}