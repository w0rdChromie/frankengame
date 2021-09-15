using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Xspeed; //sets a variable for vertical speed
    public float DestroyTime = 5f; //time in seconds before deleting bullet
    public bool SloMo; //check to see if slomo is enabled

    // Start is called before the first frame update
    void Start()
    {
        SloMo = false; //slomo is off by default
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTime -= Time.deltaTime; //as soon as bullet is created, timer decreases

        if (DestroyTime <= 0.01) //if timer reaches near zero
        {
            Destroy(gameObject); //delete the bullet
        }
        if (SloMo == true) // if slomo is enabled
        {
            transform.Translate(Xspeed/4, 0, 0); //cut speed of bullet into a quarter of normal speed
        }
        else
        {
            transform.Translate(Xspeed, 0, 0); //if slomo is disabled, move bullet at normal speed
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && SloMo == false) //if slomo isn't enabled and right mouse pressed, enable slomo
        {
            SloMo = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && SloMo == true) //if slomo is enabled and right mouse pressed, disable slomo
        {
            SloMo = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy") //if bullet collides with an enemy object
        {
            Destroy(gameObject); //destroy bullet
        }
    }
}
