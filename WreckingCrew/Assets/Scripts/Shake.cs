using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 shakerate = new Vector3(0.1f, 0.2f, 0.3f);
    public float shaketime = 0.5f;
    public float shakeDertaTime = 0.1f;
    public void shakeobject()
    {

        StartCoroutine(shake_coroutine());
    }

    public IEnumerator shake_coroutine()
    {
        var oriposition=gameObject.transform.position;
        for(float i=0; i < shaketime; i += shakeDertaTime)
        {
            gameObject.transform.position = oriposition +
                Random.Range(-shakerate.x, shakerate.x) * Vector3.right +
                Random.Range(-shakerate.y, shakerate.y) * Vector3.up +
                Random.Range(-shakerate.z, shakerate.z) * Vector3.forward;
            yield return new WaitForSeconds(shakeDertaTime);
        }
        gameObject.transform.position = oriposition;

    }
}
