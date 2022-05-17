using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver_Manager : MonoBehaviour
{
    public GameObject text_destruction_block;
    private TextMeshProUGUI text_destruction;
    private float destruction_value;
    private int current_value;

    // Start is called before the first frame update
    void Start()
    {
        text_destruction = text_destruction_block.GetComponent<TextMeshProUGUI>();
        destruction_value = PlayerPrefs.GetFloat("destruction");
        current_value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(current_value < destruction_value) {
            ++current_value;
            text_destruction.text = "DESTRUCTION CAUSED:\n"+current_value;
        }

        if(TiltFive.Input.GetTrigger() > 0.5f) { SceneManager.LoadSceneAsync(0); }
    }
}
