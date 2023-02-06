using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D redball;
   
    public int speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        redball = GetComponent<Rigidbody2D>();
        launch();
    }

    // Update is called once per frame
    public void launch()
    {
        float x1 = Random.value < 0.5f ? Random.Range(-1f, -.5f) : Random.Range(.5f,1f);
        float y1 = Random.value < 0.5f ? Random.Range(-1f, -.5f) : Random.Range(.5f,1f);

        Vector2 direction1 = new Vector2(x1,y1);
        redball.AddForce(direction1 * speed);

    }
    public void resetBall()
    {
        redball.transform.position = new Vector2(1.5f,0f);

    }

}
