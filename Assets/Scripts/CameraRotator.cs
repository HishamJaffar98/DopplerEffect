using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] Animator cameraRotatorAnimator;
    [SerializeField] GameObject sonicBoomLabel;
    bool cameraRotated;
    void Start()
    {
        cameraRotated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            int id = firstTouch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                return;
            }
            RotateCamera();
        }

        if (gameObject.GetComponent<AudioSource>().isPlaying)
        {
            sonicBoomLabel.SetActive(true);
        }
        else
        {
            sonicBoomLabel.SetActive(false);
        }
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButtonDown(0) && !cameraRotated)
        {
            SetFlag(true);
        }
        else if (Input.GetMouseButtonDown(0) && cameraRotated)
        {
            SetFlag(false);
        }
    }

    private void SetFlag(bool tag)
    {
        cameraRotatorAnimator.SetBool("isRotated", tag);
        StartCoroutine(Delay(tag));
    }

    IEnumerator Delay(bool tag)
    {
        yield return new WaitForSecondsRealtime(1.2f);
        cameraRotated = tag;
    }

    public void PlaySonicBoom()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }


}
