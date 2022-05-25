using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{

    public Shake shake;
    void Start() 
    { 
        PlayerPrefs.SetFloat("destruction", 0);
        shake=GameObject.FindGameObjectWithTag("Environment").GetComponent<Shake>(); 
    }
    
    public AudioSource audio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Delux"))
        {
            Explode(other);
            BuildingDetructionScore bds = other.gameObject.GetComponentInChildren<BuildingDetructionScore>();
            if (bds) bds.ScorePop();
            if (audio)
            {
                audio.Play();
                //PlayerPrefs.SetFloat("destruction", PlayerPrefs.GetFloat("destruction") + 500 + Mathf.Floor(Random.Range(250, 500)));
            }
            shake.shakeobject();
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
