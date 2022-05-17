using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject clockInside;
    private Image clockImage;
    // Start is called before the first frame update
    void Start()
    {
        clockImage = clockInside.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        clockImage.fillAmount -= Time.deltaTime / 60;
        clockImage.color = new Color(clockImage.color.r + 
        Time.deltaTime / 30, clockImage.color.g, 
        clockImage.color.b, clockImage.color.a);
        if (clockImage.fillAmount <= 0.6f) {
            clockImage.color = new Color(clockImage.color.r,
            clockImage.color.g - Time.deltaTime / 30,
            clockImage.color.b, clockImage.color.a);
        }

        //If out of time, switch to game over scene
        if(clockImage.fillAmount <= 0.01f) {
            PlayerPrefs.SetFloat("destruction", 10000+Random.Range(-2500, 2500));
            SceneManager.LoadSceneAsync(1);
        }
    }
}
