using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 shakerate = new Vector3(0.1f, 0.2f, 0.3f);
    public float shaketime = 0.05f;
    //public float shakeDertaTime = 0.01f;
    public void shakeobject()
    {

        StartCoroutine(shake_coroutine());
    }

    public IEnumerator shake_coroutine()
    {
        var oriposition=gameObject.transform.position;
        for(float i=0; i < shaketime; i += Time.deltaTime)
        {
            gameObject.transform.position = oriposition +
               Vector3.Lerp(Vector3.zero, shakerate, 2*Time.deltaTime);

            yield return new WaitForSeconds(Time.deltaTime);
        }
        gameObject.transform.position = oriposition;

    }
}
