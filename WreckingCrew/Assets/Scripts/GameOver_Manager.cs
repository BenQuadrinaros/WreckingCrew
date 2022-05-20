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
    private float current_value;
    private int goal;
    public List<GameObject> goal_effects;

    // Start is called before the first frame update
    void Start()
    {
        text_destruction = text_destruction_block.GetComponent<TextMeshProUGUI>();
        destruction_value = PlayerPrefs.GetFloat("destruction");
        current_value = 0;
        goal = 250;
    }

    // Update is called once per frame
    void Update()
    {
        if(current_value < destruction_value) {
            current_value += destruction_value*Time.deltaTime/2.5f;
            text_destruction.text = "DESTRUCTION CAUSED:\n"+(int)current_value;
            if(current_value > goal) {
                for(int i = 0; i < 3; ++i) {
                    Instantiate(goal_effects[0], new Vector3(Random.Range(-10, 10), 0, Random.Range(-5, 5)), new Quaternion());
                }
                goal += 250;
                goal_effects.Add(goal_effects[0]);
                goal_effects.RemoveAt(0);
            }
        }

        if(TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKey("space")) { SceneManager.LoadSceneAsync(0); }

        
        if(UnityEngine.Input.GetKey("escape")) { Application.Quit(); }
    }
}
