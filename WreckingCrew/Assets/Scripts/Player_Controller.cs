using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class Player_Controller : MonoBehaviour
{
    private Transform crane_arm;

    #region Crane variables
    [Header("Crane Variables")]
    [SerializeField] float crane_Speed = 4f;
    [SerializeField] float crane_Rotation_Speed = 2.5f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        crane_arm = transform.Find("Crane_Arm");
    }

    // Update is called once per frame
    void Update()
    {
        TiltFive.Input.TryGetStickTilt(out Vector2 stick_tilt);
        if(Mathf.Abs(stick_tilt.x) > 0.5f) {
            transform.Rotate(0, stick_tilt.x * 60 * Time.deltaTime * crane_Rotation_Speed, 0);
        } else if(UnityEngine.Input.GetKey("a")) {
            transform.Rotate(0, -1 * 60 * Time.deltaTime * crane_Rotation_Speed, 0);
        } else if(UnityEngine.Input.GetKey("d")) {
            transform.Rotate(0, 60 * Time.deltaTime * crane_Rotation_Speed, 0);
        }
        if(Mathf.Abs(stick_tilt.y) > 0.5f) {
            transform.position += transform.forward * stick_tilt.y * Time.deltaTime * crane_Speed;
        } else if(UnityEngine.Input.GetKey("w")) {
            transform.position += transform.forward * Time.deltaTime * crane_Speed;
        } else if(UnityEngine.Input.GetKey("s")) {
            transform.position += -1*transform.forward * Time.deltaTime * crane_Speed;
        }

        crane_arm.localRotation = Quaternion.Lerp(crane_arm.localRotation, TiltFive.Wand.GetRotation(), 3*Time.deltaTime);
    }
}
