using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingDetructionScore : MonoBehaviour
{
    public Transform cam;
    public TMP_Text scoreText;
    public Animator anim;
    public float scoreToIncrement;


    public void ScorePop()
    {
        Debug.Log("Score pop");
        anim.SetTrigger("ScorePop");
        float randomValue = 500 + Mathf.Floor(Random.Range(250, 500));
        scoreText.text = randomValue.ToString();
        PlayerPrefs.SetFloat("destruction", PlayerPrefs.GetFloat("destruction") + randomValue);
        scoreText.gameObject.SetActive(true);
        transform.LookAt(transform.position + cam.forward);
    }

    public void ScoreDisable()
    {
        scoreText.gameObject.SetActive(false);
    }
    
}
