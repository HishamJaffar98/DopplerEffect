using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<Resetter>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private static void ResetPlayerPrefs()
    {
        PlayerPrefsUtility.SetMusicToggle(1);
        PlayerPrefsUtility.SetMusicLevel(0.3f);
    }

    void Start()
    {
        ResetPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
