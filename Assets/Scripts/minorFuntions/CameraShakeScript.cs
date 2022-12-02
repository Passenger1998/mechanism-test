using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public bool handheldMode = false;
    public AnimationCurve animationCurve;
    public float shakeDuration;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (handheldMode)
        {
            handheldMode = false;
            StartCoroutine(ConstantHandHeldShake());
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

}
