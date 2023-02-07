using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoarderController : MonoBehaviour
{
    SpriteRenderer sr;
    float flashTime = 0.2f;
    bool damageFlashEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void InitiateFlash() {
        if (damageFlashEnabled) {
            StartCoroutine(FlashRed());
        }
    }

    public void enableFlash() {
        damageFlashEnabled = true;
    }

    public void disableFlash() {
        damageFlashEnabled = false;
    }

    IEnumerator FlashRed() {
        sr.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        sr.color = Color.white;
    }
}
