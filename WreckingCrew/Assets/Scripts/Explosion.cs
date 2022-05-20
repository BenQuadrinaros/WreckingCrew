using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce;
    public float radius = 5f;
    

    public void Explode()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.gameObject.GetComponent<MeshCollider>().enabled = true;
        rb.useGravity = true;
        rb.AddExplosionForce(explosionForce * 100, transform.position, radius);
        rb.drag = 1f;
        rb.angularDrag = 5;
        Invoke("Destroy", 5f);
    }

    void Destroy()
    {
        if(Random.Range(0, 100) > 20)
        {
            Destroy(gameObject);
        }
    }
}
