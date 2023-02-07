using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public AnimationCurve curve;

    bool shakeEnabled;
    float duration;

    // Start is called before the first frame update
    void Start()
    {
        shakeEnabled = false;
        duration = 0.2f;
    }

    public void InitiateShake() {
        if (shakeEnabled) {
            StartCoroutine(shake());
        }
    }
    IEnumerator shake() {
        Vector3 ogCamPos = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = ogCamPos + (Vector3)Random.insideUnitCircle * strength;
            yield return null;
        }

        transform.position = ogCamPos;
    }

    public void enableShake() {
        shakeEnabled = true;
    }

    public void disableShake() {
        shakeEnabled = false;
    }
}
