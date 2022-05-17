using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTrack : MonoBehaviour
{
    public float speed = 2;
    public float power = 5;
    Transform target;
    public float turnSpeed = 1;
    
    private Coroutine turnCoroutine;
    public Transform[] pathNodes;
    int currentNode = 0;

    public GameObject explosionParticle;

    public AudioSource expaudio;
    public AudioClip expclip;
    // Start is called before the first frame update
    void Start()
    {
        target = pathNodes[0];
        expaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        turnToTarget();
        if (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else {
            if (currentNode < pathNodes.Length - 1)
            {
                currentNode += 1;
                //target = pathNodes[currentNode];
            }
            else {
                currentNode = 0;
            }
            target = pathNodes[currentNode];
        }
    }


    void turnToTarget() {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("qq");
            StartCoroutine(playexpsound());
            collision.gameObject.GetComponent<Player_Controller>().Stun(power);
            //expaudio.PlayOneShot(expclip,1f);
           explosion();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wrecking_Ball") {
            Debug.Log("vv");
            StartCoroutine(playexpsound());
            collision.gameObject.transform.parent.gameObject.GetComponent<Player_Controller>().Stun(power);
            //expaudio.PlayOneShot(expclip, 1f);
            explosion();
        }
    }
    IEnumerator playexpsound()
    {
        expaudio.PlayOneShot(expclip,1f);
        yield return 1.0f;
    }
    void explosion() { 
        GameObject exP = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        //expaudio.PlayOneShot(expclip,1f);
        //Destroy(this.gameObject);
        
        
        Destroy(exP, 1.5f);
        Destroy(this.gameObject);
    }

}
