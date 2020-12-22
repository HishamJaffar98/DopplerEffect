using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class PlayerPrefsUtility
{

    const string MUSIC_KEY = "musicToggle";
    const string VOLUME_LEVEL = "volumeLevel";
    public static void SetMusicToggle(int value)
    {
        PlayerPrefs.SetInt(MUSIC_KEY, value);
    }

    public static int GetMusicToggle()
    {
        return PlayerPrefs.GetInt(MUSIC_KEY);
    }

    public static void SetMusicLevel(float value)
    {
        PlayerPrefs.SetFloat(VOLUME_LEVEL, value);
    }

    public static float GetMusicLevel()
    {
        return PlayerPrefs.GetFloat(VOLUME_LEVEL);
    }
}
