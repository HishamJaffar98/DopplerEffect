using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Sound Toggle")]
    [SerializeField] GameObject soundToggleButton;
    [SerializeField] Sprite[] soundToggleSprites;

    [Header("Volume Slider")]
    [SerializeField] Slider volumeSlider;

    [Header("Music Toggle")]
    [SerializeField] Sprite[] musicToggleSprites;
    [SerializeField] GameObject musicToggleButton;

    [Header("Label Toggle")]
    [SerializeField] Sprite[] labelToggleSprites;

    [Header("Info Toggle")]
    [SerializeField] Sprite[] infoToggleSprites;
    [SerializeField] Animator infoPanelAnimator;

    float prevVolumeLevel;
    float prevMusicLevel;
    bool infoToggled;
    GameObject[] labelArray;
    AudioManager audioManager;
    GameObject narrator;

    private void Awake()
    {
        volumeSlider.value = PlayerPrefsUtility.GetMusicLevel();
    }
    void Start()
    {
        infoToggled = false;
        labelArray =GameObject.FindGameObjectsWithTag("Label");
        audioManager = FindObjectOfType<AudioManager>();
        narrator = GameObject.FindGameObjectWithTag("Narrator");
        if (PlayerPrefsUtility.GetMusicToggle() == 0)
        {
            musicToggleButton.GetComponent<Image>().sprite = musicToggleSprites[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        DynamicSoundToggle();
        PlayerPrefsUtility.SetMusicLevel(volumeSlider.value);
    }

    private void DynamicSoundToggle()
    {
        if (volumeSlider.value != 0)
        {
            soundToggleButton.GetComponent<Image>().sprite = soundToggleSprites[0];
        }
        else
        {
            soundToggleButton.GetComponent<Image>().sprite = soundToggleSprites[1];
        }
    }

    public void SwapSpriteEvent()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "SoundToggleButton":
                {
                    SpriteSwap(soundToggleSprites);
                    break;
                }
            case "MusicToggleButton":
                {
                    SpriteSwap(musicToggleSprites);
                    break;
                }
            case "LabelToggleButton":
                {
                    SpriteSwap(labelToggleSprites);
                    break;
                }
            case "InfoToggleButton":
                {
                    SpriteSwap(infoToggleSprites);
                    break;
                }
        }
    }

    private void SpriteSwap(Sprite[] spriteArray)
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite == spriteArray[0])
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = spriteArray[1];
        }
        else if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite == spriteArray[1])
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = spriteArray[0];
        }
    }

    public void ToggleSound()
    {
        if(volumeSlider.value!=0)
        {
            prevVolumeLevel = volumeSlider.value;
            volumeSlider.value = 0;
        }
        else
        {
            volumeSlider.value = prevVolumeLevel;
        }
    }

    public void ToggleLabels()
    {
        foreach(GameObject label in labelArray)
        {
            if(label.activeSelf==true)
            {
                label.SetActive(false);
            }
            else
            {
                label.SetActive(true);
            }
        }
    }

    public void ToggleInfo()
    {
        if(!infoToggled)
        {
            infoPanelAnimator.SetBool("activatePanel", true);
            narrator.gameObject.GetComponent<AudioSource>().Play();
            infoToggled = true;
        }
        else
        {
            infoPanelAnimator.SetBool("activatePanel", false);
            narrator.gameObject.GetComponent<AudioSource>().Stop();
            infoToggled = false;
        }
    }

    public void ToggleMusic()
    {
        if(PlayerPrefsUtility.GetMusicToggle()==1)
        {
            audioManager.gameObject.GetComponent<AudioSource>().Pause();
            PlayerPrefsUtility.SetMusicToggle(0);
        }
        else if(PlayerPrefsUtility.GetMusicToggle() == 0)
        {
            audioManager.gameObject.GetComponent<AudioSource>().Play();
            PlayerPrefsUtility.SetMusicToggle(1);
        }
    }
}
