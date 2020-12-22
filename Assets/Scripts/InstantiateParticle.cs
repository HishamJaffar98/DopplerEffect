using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateParticle : MonoBehaviour
{
    [SerializeField] GameObject initialWaves;
    [SerializeField] Animator emittingWavesAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<MoveCar>())
        {
            GameObject particles = Instantiate(initialWaves);
            emittingWavesAnimator.SetBool("fadeIn", true);
        }
    }
}
