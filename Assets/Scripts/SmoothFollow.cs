using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] float smoothSpeed = 0.125f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(objectToFollow.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.position = Vector3.Lerp(transform.position,desiredPosition,1);
    }
}
