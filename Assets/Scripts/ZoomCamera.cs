using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] float maxFOV = 70f;
    [SerializeField] float minFOV = 45f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount==2)
        {
            foreach(Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if(EventSystem.current.IsPointerOverGameObject(id))
                {
                    return;
                }
            }
            Touch zeroTouch = Input.GetTouch(0);
            Touch firstTouch = Input.GetTouch(1);
            Vector2 zeroTouchPrevPos = zeroTouch.position - zeroTouch.deltaPosition;
            Vector2 firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            float prevMag = (zeroTouchPrevPos - firstTouchPrevPos).magnitude;
            float currentMag = (zeroTouch.position - firstTouch.position).magnitude;
            float difference = currentMag - prevMag;
            Zoom(difference*0.4f);
        }
    }

    private void Zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, minFOV, maxFOV);
    }
}
