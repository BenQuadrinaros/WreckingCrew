using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public ParticleSystem[] instantParticles;
    public ParticleSystem[] loopingParticles;
    public Shake shake;

<<<<<<< Updated upstream

     void Start()
    {
        shake = GameObject.FindGameObjectWithTag("Environment").GetComponent<Shake>();
=======
     void Start()
    {
        shake=GameObject.FindGameObjectWithTag("Environment").GetComponent<Shake>();
>>>>>>> Stashed changes
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            instantParticles[Random.Range(0, instantParticles.Length)].Play();
            instantParticles[Random.Range(0, instantParticles.Length)].Play();
            Invoke("SpawnLoopingParticles", 1f);
            shake.shakeobject();
        }
    }

    void SpawnLoopingParticles()
    {
        loopingParticles[Random.Range(0, loopingParticles.Length)].Play();
    }
}
