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
    // Start is called before the first frame update
    void Start()
    {
        target = pathNodes[0];
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
            collision.gameObject.GetComponent<Player_Controller>().Stun(power);
            explosion();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wrecking_Ball") {
            collision.gameObject.transform.parent.gameObject.GetComponent<Player_Controller>().Stun(power);
            explosion();
        }
    }

    void explosion() { 
        GameObject exP = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(exP, 1.5f);
    }

}
