using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject clockInside;
    public GameObject redBar;
    private Image clockImage;
    float flashTime = 0.5f;
    float flashTimer = 0;
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

        if (clockImage.fillAmount <= 0.35f) {
            flash();
        }

        //If out of time, switch to game over scene
        if(clockImage.fillAmount <= 0.01f) {
            SceneManager.LoadSceneAsync(1);
        }
    }


    void flash() {
        if (flashTimer < flashTime)
        {
            flashTimer += Time.deltaTime;
        }
        else {
            flashTimer = 0;
            redBar.SetActive(!redBar.active);
        }
    }


}
