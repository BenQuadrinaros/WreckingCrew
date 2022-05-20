using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public ParticleSystem[] instantParticles;
    public ParticleSystem[] loopingParticles;
    public Vector3 shakerate = new Vector3(0.1f,0.1f,0.1f);
    public float shaketime = 0.5f;
    public float shakeDertatime = 0.1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            instantParticles[Random.Range(0, instantParticles.Length)].Play();
            instantParticles[Random.Range(0, instantParticles.Length)].Play();
            Invoke("SpawnLoopingParticles", 1f);
            //StartCoroutine(ShakeCoroutine());
        }
    }

    void SpawnLoopingParticles()
    {
        loopingParticles[Random.Range(0, loopingParticles.Length)].Play();
    }

    private void Update()
    {
        StartCoroutine(ShakeCoroutine());
    }
    IEnumerator ShakeCoroutine()
    {
        var oriposition = gameObject.transform.position;
        for(float i=0;i<shaketime;i+=shakeDertatime)
        {
            gameObject.transform.position = oriposition +
                Random.Range(-shakerate.x, shakerate.x) * Vector3.right +
                Random.Range(-shakerate.y, shakerate.y) * Vector3.up +
                Random.Range(-shakerate.z, shakerate.z) * Vector3.forward;
            yield return new WaitForSeconds(shakeDertatime);
        }
        gameObject.transform.position = oriposition;

    }
}
