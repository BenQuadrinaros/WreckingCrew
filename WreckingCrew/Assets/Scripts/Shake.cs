using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< Updated upstream

    public Vector3 shakerate = new Vector3(0.1f,0.1f,0.1f);
    public float shaketime = 0.5f;
    public float shakedertatime = 0.1f;
    void Start()
    {
        
    }
=======
    public float shaketime=0.5f;
    public Vector3 shakerate=new Vector3(0.1f,0.1f,0.1f);
    public float shakedelratime=0.1f;
 
>>>>>>> Stashed changes
    public void shakeobject()
    {
        StartCoroutine(shakecoroutine());
    }
<<<<<<< Updated upstream

    // Update is called once per frame
    public IEnumerator shakecoroutine()
    {
        var oriposition=gameObject.transform.position;
        for(float i = 0; i < shaketime; i += shakedertatime)
        {

            gameObject.transform.position = oriposition +
                Random.Range(-shakerate.x, shakerate.x) * Vector3.right +
                Random.Range(-shakerate.y, shakerate.y) * Vector3.up +
                Random.Range(-shakerate.z, shakerate.z) * Vector3.forward;
            yield return new WaitForSeconds(shakedertatime);
        }
        gameObject.transform.position = oriposition;
=======
    public IEnumerator shakecoroutine()
    {
        var oriposition=transform.position;
        for (float i = 0; i < shaketime; i += shakedelratime)
        {
            gameObject.transform.position = oriposition +
                Random.Range(-shakerate.x, shakerate.x) * Vector3.right +
                 Random.Range(-shakerate.y, shakerate.y) * Vector3.up +
                  Random.Range(-shakerate.z, shakerate.z) * Vector3.forward;
            yield return new WaitForSeconds(shakedelratime);
        }
        gameObject.transform.position=oriposition;
        
>>>>>>> Stashed changes
    }
}
