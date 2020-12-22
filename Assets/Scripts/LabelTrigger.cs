using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelTrigger : MonoBehaviour
{
    [SerializeField] Animator approachingAnimator;
    [SerializeField] Animator recedingAnimator;
    void Start()
    {
        approachingAnimator.SetBool("FadeOut", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<MoveCar>())
        {
            approachingAnimator.SetBool("FadeOut", true);
            recedingAnimator.SetBool("FadeOut", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
