using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClampLabel : MonoBehaviour
{
    [SerializeField] GameObject nameLabel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 screenCoordsOfObject = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = screenCoordsOfObject;
    }
}
