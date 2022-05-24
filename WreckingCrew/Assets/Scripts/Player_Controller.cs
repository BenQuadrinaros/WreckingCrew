using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class Player_Controller : MonoBehaviour
{
    private Transform crane_arm;
    private GameObject UI;
    private AudioSource audio_reverse;
    private bool reversing;
    bool stunned = false;
    private float stun_timer = 0;
    private float stun_apex = 0;
    private Vector3 stun_orientation_position;

    [Header("Rotation Settins")]
    public bool rotateWorld = true;
    public GameObject rotatableWorld;
    public float rotationSpeed = 60.0f;

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
        UI = GameObject.Find("UI");
        audio_reverse = transform.Find("Audio_Reverse").gameObject.GetComponent<AudioSource>();
        reversing = false;
        minAnchorYValue = wreakingBallHingeJoint.anchor.y;
    }

    // Update is called once per frame
    void Update()
    {
        UI.transform.position = new Vector3(transform.position.x - 16.75f, transform.position.y - 1.15f, transform.position.z - 5.75f);
        TiltFive.Input.TryGetStickTilt(out Vector2 stick_tilt);
        if (!stunned) { 
            //Rotate player
            if(Mathf.Abs(stick_tilt.x) > 0.5f) {
                if (!rotateWorld)
                    transform.Rotate(0, stick_tilt.x * 60 * Time.deltaTime * crane_Rotation_Speed, 0);
                else
                    rotatableWorld.transform.RotateAround(transform.position, Vector3.up, stick_tilt.x * rotationSpeed * Time.deltaTime * crane_Rotation_Speed);
            } else if(UnityEngine.Input.GetKey("a")) {
                if (!rotateWorld)
                    transform.Rotate(0, -1 * 60 * Time.deltaTime * crane_Rotation_Speed, 0);
                else
                    rotatableWorld.transform.RotateAround(transform.position, Vector3.up, -1 * rotationSpeed * Time.deltaTime * crane_Rotation_Speed);
            } else if(UnityEngine.Input.GetKey("d")) {
                if (!rotateWorld)
                    transform.Rotate(0, 60 * Time.deltaTime * crane_Rotation_Speed, 0);
                else
                    rotatableWorld.transform.RotateAround(transform.position, Vector3.up, 1 * rotationSpeed * Time.deltaTime * crane_Rotation_Speed);
            }

            //Move player forward/backward
            if(Mathf.Abs(stick_tilt.y) > 0.5f) {
                transform.position += transform.forward * stick_tilt.y * Time.deltaTime * crane_Speed;
                //UI.transform.position += transform.forward * stick_tilt.y * Time.deltaTime * crane_Speed;
            } else if(UnityEngine.Input.GetKey("w")) {
                transform.position += transform.forward * Time.deltaTime * crane_Speed;
                //UI.transform.position += transform.forward * Time.deltaTime * crane_Speed;
            } else if(UnityEngine.Input.GetKey("s")) {
                transform.position += -1*transform.forward * Time.deltaTime * crane_Speed;
                //UI.transform.position += -1 * transform.forward * Time.deltaTime * crane_Speed;
            }

            //Check against world boundaries
            transform.position = new Vector3(Mathf.Max(-21, Mathf.Min(22.5f, transform.position.x)), transform.position.y, Mathf.Max(-22.5f, Mathf.Min(21, transform.position.z)));

            //Play/Stop reverse audio
            if(!reversing && (stick_tilt.y < -0.35f || UnityEngine.Input.GetKey("s"))) {
                reversing = true;
                audio_reverse.Play();
            }
            if(reversing && !(stick_tilt.y < -0.35f || UnityEngine.Input.GetKey("s"))) {
                reversing = false;
                audio_reverse.Stop();
            }

            //Trigger for lengthen chain
            if (TiltFive.Input.GetTrigger() > 0.5f)
                currentAnchorY = Mathf.Lerp(currentAnchorY, maxAnchorYValue, TiltFive.Input.GetTrigger() * 3 * Time.deltaTime);
            else if (UnityEngine.Input.GetMouseButton(0))
                currentAnchorY = Mathf.Lerp(currentAnchorY, maxAnchorYValue, 3 * Time.deltaTime);
            else
                currentAnchorY = Mathf.Lerp(currentAnchorY, minAnchorYValue, 3 * Time.deltaTime);
            wreakingBallHingeJoint.anchor = new Vector3(0, currentAnchorY, 0);
            crane_arm.localRotation = Quaternion.Lerp(crane_arm.localRotation, TiltFive.Wand.GetRotation(), 3*Time.deltaTime);
        } else {
            transform.Rotate(210*Time.deltaTime, 210*Time.deltaTime, 210*Time.deltaTime);
            if(stun_timer > stun_apex + 0.25f) {
                transform.position += new Vector3(0, 7.5f*Time.deltaTime, 0);
            } else if(stun_timer < stun_apex - 0.25f) {
                transform.position += new Vector3(0, -7.5f*Time.deltaTime, 0);
            }

            stun_timer -= Time.deltaTime;
            if(stun_timer < 0) {
                stunned = false;
                transform.position = stun_orientation_position;
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            }
        }
    }

    public void Stun(float stunTime) {
        stunned = true;
        stun_timer = stunTime;
        stun_apex = stunTime/2;
        stun_orientation_position = transform.position;
    }
}
