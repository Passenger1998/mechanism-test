using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public bool shake = false;
    public bool shake_continuously = false;
    public AnimationCurve animationCurve;
    public float shakeDuration;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            shake = false;
            StartCoroutine(ConstantHandHeldShake());
        }

        if (shake_continuously)
        {
            ContinuousShake();
        }
    }

    IEnumerator ConstantHandHeldShake()
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = animationCurve.Evaluate(elapsedTime / shakeDuration);
            transform.position = startPos + UnityEngine.Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;

    }

    void ContinuousShake()
    {
        int i = 1;
     
    }

}
