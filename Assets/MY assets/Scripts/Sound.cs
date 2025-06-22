using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public GameObject Slider;
    AudioSource MusicScript;
    Slider SliderScript;

    private void Start()
    {
        MusicScript = gameObject.GetComponent<AudioSource>();
        SliderScript = Slider.GetComponent<Slider>();
    }

    private void Update()
    {
        MusicScript.volume = SliderScript.value;
    }
}
