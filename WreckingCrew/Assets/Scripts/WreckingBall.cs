using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{

    public Shake shake;
    Game_Manager gameManager;

    void Start() 
    { 
        PlayerPrefs.SetFloat("destruction", 0);
        shake=GameObject.FindGameObjectWithTag("Environment").GetComponent<Shake>();
        gameManager = GameObject.Find("Tilt Five Prototype").GetComponent<Game_Manager>();
    }
    
    public AudioSource audio;
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.swinging) {
            if (other.gameObject.CompareTag("Delux"))
            {
                Explode(other);
                BuildingDetructionScore bds = other.gameObject.GetComponentInChildren<BuildingDetructionScore>();
                if (bds) bds.ScorePop();
                if (audio)
                {
                    audio.Play();
                }
                //shake.shakeobject();
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
