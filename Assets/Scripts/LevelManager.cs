using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator faderAnimator;
    int currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene()
    {
        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "Scene1Button":
                StartCoroutine(AllowSceneSwitch(0));
                break;
            case "Scene2Button":
                StartCoroutine(AllowSceneSwitch(1));
                break;
            case "Scene3Button":
                StartCoroutine(AllowSceneSwitch(2));
                break;
            case "Scene4Button":
                StartCoroutine(AllowSceneSwitch(3));
                break;
        }
    }

    IEnumerator AllowSceneSwitch(int index)
    {
        if (currentScene == index)
        {
            yield return new WaitForSecondsRealtime(0f);
        }
        else
        {
            faderAnimator.SetTrigger("sceneSwitch");
            yield return new WaitForSecondsRealtime(0.7f);
            SceneManager.LoadScene(index);
        }
    }
}
