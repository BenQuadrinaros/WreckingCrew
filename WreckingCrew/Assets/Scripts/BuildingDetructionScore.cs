using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingDetructionScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public Animator anim;
    public float scoreToIncrement;

    public void ScorePop()
    {
        anim.SetTrigger("ScorePop");
        float randomValue = 500 + Mathf.Floor(Random.Range(250, 500));
        scoreText.text = randomValue.ToString();
        PlayerPrefs.SetFloat("destruction", PlayerPrefs.GetFloat("destruction") + randomValue);
        scoreText.gameObject.SetActive(true);
    }

    public void ScoreDisable()
    {
        scoreText.gameObject.SetActive(false);
    }
    
}
