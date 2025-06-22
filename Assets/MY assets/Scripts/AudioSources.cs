using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSources : MonoBehaviour
{
    public AudioClip Buy;
    public AudioClip Sell;
    public AudioClip Oof;
    public AudioClip AAA;
    public AudioClip Death;
    public static AudioSources instance;

    private void Awake()
    {
        if (AudioSources.instance == null) instance = this;
        else Destroy(gameObject);
    }
}
