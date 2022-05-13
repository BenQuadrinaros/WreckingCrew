using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public float raduis;
    public float force;
    public float upwardModfier;
    public Camera camera;
    public GameObject VFX_Exploasion;
    public AudioSource audioSource;
    public AudioClip OpenDoorSound;

    void Start()
    {
        audioSource= GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Piece")
        {
            
            CheckCollision();
            Instantiate(VFX_Exploasion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            audioSource.PlayOneShot(OpenDoorSound,1f);
        }
        if(collision.gameObject.tag =="Delux")
        {

            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1),ForceMode.Impulse);
            collision.collider.attachedRigidbody.angularDrag=0;
            collision.collider.attachedRigidbody.drag=0;
            Instantiate(VFX_Exploasion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            audioSource.PlayOneShot(OpenDoorSound,1f);

        }


    }
    // void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.tag =="Piece")
    //    {

    //        CheckCollision();
    //    }
    //}

    void OnCollisionStay(Collision collision)
    {

    }

    void OnCollisionExit(Collision collision)
    {

       
    }

    void CheckCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.ScreenPointToRay(camera.WorldToScreenPoint(transform.position)), out hit))

        { 

            //Debug.Log("AddExplosionForce");

            Collider[] hits;

            hits = Physics.OverlapSphere(hit.point, raduis);
            Debug.Log(transform.position);

            foreach (Collider t in hits)

            {

                if (t != null && t.attachedRigidbody != null)
                {
                    
                    t.attachedRigidbody.drag = 0;
                    t.attachedRigidbody.angularDrag = 0;
                    t.attachedRigidbody.useGravity = true;
                    t.attachedRigidbody.AddExplosionForce(force, t.attachedRigidbody.position, raduis, upwardModfier, ForceMode.Impulse);
                    
                }


            }

            }
        
    }
    //void CheckCollisionWithoutExp()
    //{
    //    RaycastHit hit; 
    //    if (Physics.Raycast(camera.ScreenPointToRay(camera.WorldToScreenPoint(transform.position)), out hit))

    //    {

    //        //Debug.Log("AddExplosionForce");

    //        Collider[] hits;

    //        hits = Physics.OverlapSphere(hit.point, raduis);
    //        Debug.Log(transform.position);
    //        foreach (Collider t in hits)

    //        {

    //            if (t != null && t.attachedRigidbody != null)
    //            {

    //                t.attachedRigidbody.drag = 0;
    //                t.attachedRigidbody.angularDrag = 0;
    //                t.attachedRigidbody.useGravity = true;
    //                t.attachedRigidbody.AddForce(transform.rotation.eulerAngles, ForceMode.Impulse);

    //            }


    //        }

    //    }
    //}
}
