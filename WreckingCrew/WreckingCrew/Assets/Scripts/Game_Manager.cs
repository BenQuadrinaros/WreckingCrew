using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //Scene references
    public Transform player_crane;
    public Transform tiltFive_board;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta_center = player_crane.position - tiltFive_board.position;
        if(delta_center.sqrMagnitude > 10) {
            tiltFive_board.position += delta_center*Time.deltaTime;
        }
    }
}
