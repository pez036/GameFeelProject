using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;
    TrailRenderer trail;
    float speed = 500f;

    bool chipAwayHealthEnabled;
    float damageMultiplier;
    float health;
    float lerpTimer;
    float chipSpeed = 20f;
    public float maxHealth = 100f;
    public Image frontHealthBar;
    public Image backHealthBar;

    public CamController camController;
    public DamageBoarderController dmgFlash;

    void Start()
    {
        health = maxHealth;
        damageMultiplier = 2f;
        player = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        chipAwayHealthEnabled = false;
        launch();
    }

    void Update() {
        updateHealthUI();
    }

    public void launch()
    {
        float x1 = Random.value < 0.5f ? Random.Range(-1f, -.5f) : Random.Range(.5f,1f);
        float y1 = Random.value < 0.5f ? Random.Range(-1f, -.5f) : Random.Range(.5f,1f);

        Vector2 direction1 = new Vector2(x1,y1);
        player.AddForce(direction1 * speed);

    }
    public void resetBallAt(Vector2 spawn) {
        health = maxHealth;
        //damageMultiplier = 2f;
        player.velocity = Vector2.zero;
        player.transform.position = spawn;
        launch();
        

    }

    public void updateHealthUI() {
        float fillFront = frontHealthBar.fillAmount;
        float fillBack = backHealthBar.fillAmount;
        float healthPercentage = health / maxHealth;
        if (chipAwayHealthEnabled && fillBack > healthPercentage) {
            frontHealthBar.fillAmount = healthPercentage;
            lerpTimer += Time.deltaTime;
            float percentageComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillBack, healthPercentage, percentageComplete);
        } else {
            backHealthBar.fillAmount = healthPercentage;
        }
        frontHealthBar.fillAmount = healthPercentage;
    }

    public void takeDamage(float dmg) {
        float healthPercentage = health / maxHealth;
        health -= dmg;
        lerpTimer = 0f;
        if (chipAwayHealthEnabled) {
            damageMultiplier = 5 * Mathf.Log10(4f - 3f * healthPercentage);
        } else {
            damageMultiplier = 2f;
        }
        if (health <= 0) {
            resetBallAt(new Vector2(3.0f, 0f));
        }
    }

    public void enableChipAwayHealth(bool isEnabled) {
        chipAwayHealthEnabled = isEnabled;
    }

    public void disableTrail() {
        GetComponent<TrailRenderer>().enabled = false;
    }

    public void enableTrail() {
        GetComponent<TrailRenderer>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            float dmg = collision.relativeVelocity.magnitude - player.velocity.magnitude;
            dmg = Mathf.Clamp(dmg, 0, dmg) * damageMultiplier;
            takeDamage(dmg);
            //updateHealthUI();
            camController.InitiateShake();
            dmgFlash.InitiateFlash();
            
        }
    }

}
