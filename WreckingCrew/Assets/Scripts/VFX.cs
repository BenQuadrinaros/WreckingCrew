using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public ParticleSystem[] instantParticles;
    public ParticleSystem[] loopingParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            instantParticles[Random.Range(0, instantParticles.Length)].Play();
            instantParticles[Random.Range(0, instantParticles.Length)].Play();
            Invoke("SpawnLoopingParticles", 1f);
        }
    }

    void SpawnLoopingParticles()
    {
        loopingParticles[Random.Range(0, loopingParticles.Length)].Play();
    }
}
