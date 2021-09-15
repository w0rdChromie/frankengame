using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.07f; //creates a speed float to determine target move speed

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 8.4) //if the target goes beyond the right edge, make speed negative and move to the left
        {
            speed = -speed;

        }
        else if (transform.position.x < -8.4) //if the target goes beyond the left edge, make speed negative and move to the right
        {
            speed = -speed;

        }
        Vector2 newPos = new Vector2(transform.position.x + speed, transform.position.y); //makes a new Vector2 of current position and to add speed to position to make target move

        transform.position = newPos; //puts the target in the new position

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bullet") //if target is hit by a bullet object
        {
            Destroy(gameObject); //destroy target
        }
    }
}
