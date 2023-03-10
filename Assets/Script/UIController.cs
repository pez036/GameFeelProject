using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerController[] Players;
    public CamController camControl;
    public GameObject[] walls;
    public DamageBoarderController dbController;
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
            dbController.disableFlash();
            GetComponent<Image>().color = Color.black;
        }
        else {
            //Debug.Log("damage boarder on");
            dbController.enableFlash();
            GetComponent<Image>().color = Color.red;
        }
        btnActive = !btnActive;
    }
    public void OnSoundEffectButtonPressed() {
        if (btnActive) {
            //Debug.Log("sound effect off");
            foreach (PlayerController player in Players) {
                player.enableCollisionSound(false);
            }
            GetComponent<Image>().color = Color.black;
        }
        else {
            foreach (PlayerController player in Players) {
                player.enableCollisionSound(true);
            }
            GetComponent<Image>().color = Color.red;
        }
        btnActive = !btnActive;
    }
    public void OnChipAwayHealthButtonPressed() {
        if (btnActive) {
            GetComponent<Image>().color = Color.black;
            foreach (PlayerController player in Players) {
                player.enableChipAwayHealth(false);
            }
        }
        else {
            GetComponent<Image>().color = Color.red;
            foreach (PlayerController player in Players) {
                player.enableChipAwayHealth(true);
            }
        }
        btnActive = !btnActive;
    }

    public void OnResetPressed() {
        Players[0].resetBallAt(new Vector2(1.5f, 0f));
        Players[1].resetBallAt(new Vector2(4.5f, 0f));
    }
}
