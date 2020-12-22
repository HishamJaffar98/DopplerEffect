using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecedingParticles : MonoBehaviour
{
    [SerializeField] GameObject[] recedingParticles;
    [SerializeField] Animator[] waveAnimators;
    GameObject initalWaves;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("initalWaves"))
        {
            initalWaves = GameObject.FindGameObjectWithTag("initalWaves");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        waveAnimators[0].SetBool("fadeIn", false);
        waveAnimators[1].SetBool("fadeIn", true);
        Destroy(initalWaves);
        if(other.tag=="Car1")
        {
            InstantiateParticle(0);
        }
        else if(other.tag=="Car2")
        {
            InstantiateParticle(1);
        }
        else if(other.tag=="Car3")
        {
            InstantiateParticle(2);
        }
    }

    private void InstantiateParticle(int index)
    {
        GameObject particles = Instantiate(recedingParticles[index]);
        Destroy(particles, 2f);
    }
}
