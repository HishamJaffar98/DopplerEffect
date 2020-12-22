using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject initialTeleporter;
    [SerializeField] Animator approachingAnimator;
    [SerializeField] Animator recedingAnimator;
    [SerializeField] GameObject cars;
    int carSwitch;
    void Start()
    {
        carSwitch = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<MoveCar>())
        {
            other.gameObject.transform.position = new Vector3(initialTeleporter.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            if(approachingAnimator!=null && recedingAnimator!=null)
            {
                approachingAnimator.SetBool("FadeOut", false);
                recedingAnimator.SetBool("FadeOut", true);
            }
            if(cars!=null)
            {
                CarSwitch();
            }

        }
    }

    private void CarSwitch()
    {
        carSwitch++;
        for(int i=0;i<cars.transform.childCount;i++)
        {
            cars.transform.GetChild(i).gameObject.SetActive(false);
        }
        switch ((carSwitch % 3))
        {
            case 0:
                cars.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                cars.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                cars.transform.GetChild(2).gameObject.SetActive(true);
                break;
        }
    }

    void Update()
    {
        
    }
}
