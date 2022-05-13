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

    #region Chain Components
    public HingeJoint wreakingBallHingeJoint;
    public float maxAnchorYValue = 1.5f;
    private float minAnchorYValue = 0.5f;
    private float currentAnchorY = 0.0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        crane_arm = transform.Find("Crane_Arm");
        minAnchorYValue = wreakingBallHingeJoint.anchor.y;
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

        if (TiltFive.Input.GetTrigger() > 0.5f)
            currentAnchorY = Mathf.Lerp(currentAnchorY, maxAnchorYValue, TiltFive.Input.GetTrigger() * 3 * Time.deltaTime);
        else if (UnityEngine.Input.GetMouseButton(0))
            currentAnchorY = Mathf.Lerp(currentAnchorY, maxAnchorYValue, 3 * Time.deltaTime);
        else
            currentAnchorY = Mathf.Lerp(currentAnchorY, minAnchorYValue, 3 * Time.deltaTime);
        wreakingBallHingeJoint.anchor = new Vector3(0, currentAnchorY, 0);
        crane_arm.localRotation = Quaternion.Lerp(crane_arm.localRotation, TiltFive.Wand.GetRotation(), 3*Time.deltaTime);
    }
}
