using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeLevel = 3f;// 震动幅度
    public float setShakeTime = 0.5f;   // 震动时间
    public float shakeFps = 45f;    // 震动的FPS

    private bool isshakeCamera = false;// 震动标志
    private float fps;
    private float shakeTime = 0.0f;
    private float frameTime = 0.0f;
    private float shakeDelta = 0.005f;
    private Camera selfCamera;
    public bool isShake;
    void OnEnable()
    {
        isshakeCamera = true;
        selfCamera = gameObject.GetComponent<Camera>();
        shakeTime = setShakeTime;
        fps = shakeFps;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
    }

    void OnDisable()
    {
        selfCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        isshakeCamera = false;
    }






    // Start is called before the first frame update
    void Start()
    {
        isShake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShake = true;
            StartCoroutine(shake());

        }

        if (isShake == true) 
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                if (shakeTime <= 0)
                {
                    enabled = false;
                }
                else
                {
                    frameTime += Time.deltaTime;

                    if (frameTime > 1.0 / fps)
                    {
                        frameTime = 0;
                        selfCamera.rect = new Rect(shakeDelta * (-1.0f + shakeLevel * Random.value), shakeDelta * (-1.0f + shakeLevel * Random.value), 1.0f, 1.0f);
                    }
                }
            }
        }
    }
    
   IEnumerator shake()
    {
        int i = 1;
        while (i > 0)
        {
            i--;
            yield return new WaitForSeconds(1f);
            
        }
        isShake = false;
    }

    }

    

