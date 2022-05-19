using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float shakeTime = 0.0f;
    public float fps = 20.0f;
    public float frameTime = 0.0f;
    public float shakeDelta = 0.005f;

    #region Inspector
    public Camera cam;
    public static bool isShakeCamera = false;
    #endregion
    void Start()
    {
        shakeTime = 2.0f;
        fps = 20.0f;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShakeCamera)
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                if (shakeTime <= 0)
                {
                    cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                    isShakeCamera = false;
                    shakeTime = 1.0f;
                    fps = 20.0f;
                    frameTime = 0.03f;
                    shakeDelta = 0.005f;
                }
                else
                {
                    frameTime += Time.deltaTime;

                    if (frameTime > 1.0 / fps)
                    {
                        frameTime = 0;
                        cam.rect = new Rect(shakeDelta * (-1.0f + 2.0f * Random.value), shakeDelta * (-1.0f + 2.0f * Random.value), 1.0f, 1.0f);
                    }
                }
            }
        }
    }

}
