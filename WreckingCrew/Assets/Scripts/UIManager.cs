using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject clockInside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clockInside.GetComponent<Image>().fillAmount -= Time.deltaTime / 60;
        clockInside.GetComponent<Image>().color = new Color(clockInside.GetComponent<Image>().color.r + 
        Time.deltaTime / 30, clockInside.GetComponent<Image>().color.g, 
        clockInside.GetComponent<Image>().color.b, clockInside.GetComponent<Image>().color.a);
        if (clockInside.GetComponent<Image>().fillAmount <= 0.6f) {
            clockInside.GetComponent<Image>().color = new Color(clockInside.GetComponent<Image>().color.r,
            clockInside.GetComponent<Image>().color.g - Time.deltaTime / 30,
            clockInside.GetComponent<Image>().color.b, clockInside.GetComponent<Image>().color.a);
        }
    }
}
