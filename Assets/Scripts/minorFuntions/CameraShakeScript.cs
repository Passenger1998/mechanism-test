using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public bool shake = false;
    public bool shake_long = false;
    public AnimationCurve horizonCurve;
    public AnimationCurve risingCurve;
    public float shakeDuration = 1f;
    public float long_shakeDuration = 10f;
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
            StartCoroutine(ShortShake());
        }

        if (shake_long)
        {
            shake_long = false;
            StartCoroutine(LongShake());
        }
    }

    IEnumerator ShortShake()
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = horizonCurve.Evaluate(elapsedTime / shakeDuration);
            transform.position = startPos + UnityEngine.Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;

    }

    IEnumerator LongShake()
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < long_shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = risingCurve.Evaluate(elapsedTime / long_shakeDuration);
            transform.position = startPos + UnityEngine.Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;

    }
}
