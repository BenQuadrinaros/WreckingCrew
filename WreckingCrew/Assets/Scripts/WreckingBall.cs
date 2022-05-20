using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    public AudioSource audio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Delux"))
        {
            Explode(other);
            if (audio)
            {
                audio.Play();
            }
            
        }
    }

    void Explode(Collider other)
    {
        Explosion[] children = other.GetComponentsInChildren<Explosion>();
        foreach (var item in children)
        {
            if (item.GetComponent<Explosion>() == null)
            {
                Debug.Log("NULL");
            }
            else
            {
                item.GetComponent<Explosion>().Explode();
            }

        }
        if (other.transform.GetComponent<Collider>() == null)
        {
            Debug.Log("NULL");  
        }
        else
        {
            other.transform.GetComponent<Collider>().enabled = false;
        }
    }
}
