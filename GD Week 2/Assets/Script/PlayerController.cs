using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    public int speed = 100;
    private float health;
    public float maxHealth = 100f;
    public Image frontHealthBar;
    public Image backHealthBar;

    void Start()
    {
        health = maxHealth;
        player = GetComponent<Rigidbody2D>();
        launch();
    }

    public void launch()
    {
        float x1 = Random.value < 0.5f ? Random.Range(-1f, -.5f) : Random.Range(.5f,1f);
        float y1 = Random.value < 0.5f ? Random.Range(-1f, -.5f) : Random.Range(.5f,1f);

        Vector2 direction1 = new Vector2(x1,y1);
        player.AddForce(direction1 * speed);

    }
    public void resetBall()
    {
        player.transform.position = new Vector2(1.5f,0f);

    }

    public void updateHealthUI() {
        //float fillFront = frontHealthBar.fillAmount;
        //float healthPercentage = health / maxHealth;
        frontHealthBar.fillAmount = health / maxHealth;
    }

    public void takeDamage(float dmg) {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            float dmg = collision.relativeVelocity.magnitude - player.velocity.magnitude;
            dmg = Mathf.Clamp(dmg, 0, dmg);
            takeDamage(dmg);
            updateHealthUI();
            Debug.Log(collision.gameObject.name + " lost " + dmg.ToString());
        }
    }

}
