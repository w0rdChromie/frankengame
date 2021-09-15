using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    public float speed = 0.07f; //creates a speed float to determine target move speed

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4) // if the box goes beyond the top, move down
        {
            speed = -speed;

        }
        else if (transform.position.y < -4) //if the box goes beyond the bottom, move up
        {
            speed = -speed;

        }
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + speed); //makes a new Vector2 of current position and to add speed to position

        transform.position = newPos; //puts the target in the new position

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bullet") //if target is hit by bullet object
        {
            Destroy(gameObject); //destroy target
        }
    }
}
