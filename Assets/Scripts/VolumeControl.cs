using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    Slider volumeController;
    AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(volumeController==null)
        {
            volumeController = GameObject.FindGameObjectWithTag("VolumeSlider").GetComponent<Slider>();
        }
        audioSource.volume = volumeController.value;
    }
}
