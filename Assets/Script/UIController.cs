using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerController[] Players;
    public CamController camControl;
    public GameObject[] walls;
    bool btnActive = false;

    public void OnScreenShakeButtonPressed() {
        if (btnActive) {
            //Debug.Log("screen shake off");
            GetComponent<Image>().color = Color.black;
            camControl.disableShake();
        } else {
            //Debug.Log("screen shake on");
            GetComponent<Image>().color = Color.red;
            camControl.enableShake();
        }
        btnActive = !btnActive;
        
    }
    public void OnParicleTrailButtonPressed() {
        if (btnActive) {
            //Debug.Log("particle trail off");
            GetComponent<Image>().color = Color.black;
            foreach (PlayerController player in Players) {
                player.disableTrail();
            }
        }
        else {
            //Debug.Log("particle trail on");
            GetComponent<Image>().color = Color.red;
            foreach (PlayerController player in Players) {
                player.enableTrail();
            }
        }
        btnActive = !btnActive;
    }
    public void OnDamageBoarderButtonPressed() {
        if (btnActive) {
            //Debug.Log("damage boarder off");
            GetComponent<Image>().color = Color.black;
        }
        else {
            //Debug.Log("damage boarder on");
            GetComponent<Image>().color = Color.red;
        }
        btnActive = !btnActive;
    }
    public void OnSoundEffectButtonPressed() {
        if (btnActive) {
            //Debug.Log("sound effect off");
            GetComponent<Image>().color = Color.black;
        }
        else {
            //Debug.Log("sound effect on");
            GetComponent<Image>().color = Color.red;
        }
        btnActive = !btnActive;
    }
    public void OnPlayButtonPressed() {
        //Debug.Log("play pressed");
    }

    public void OnResetPressed() {
        //Debug.Log("reset pressed");
    }
}
