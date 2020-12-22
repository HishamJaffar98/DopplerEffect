using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCamera : MonoBehaviour
{
    float yaw;
    [SerializeField] float mouseSpeed = 1f;
    [SerializeField] float minRotAngle = -30f;
    [SerializeField] float maxRotAngle = 30f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                return;
            }
        }

        if (Input.touchCount==1)
        {
            Touch firstTouch = Input.GetTouch(0);
            yaw += firstTouch.deltaPosition.x * mouseSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0f, Mathf.Clamp(yaw, minRotAngle, maxRotAngle), 0f);
        }
    }
}
