using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 20f; //speed value of mouse movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) //if up arrow pressed, move up
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //if down arrow pressed, move down
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //if lrft arrow pressed, move left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //if right arrow pressed, move right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //if no arrow pressed, stop
        }

        //Next section based on a tutorial followed on youtube (https://www.youtube.com/watch?v=mKLp-2iseDc&ab_channel=KristerCederlund)
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //sets direction to the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //determines angle of object based on mouse position
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); //stores rotationbased on the angle of the object
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Speed * Time.deltaTime); //changes player rotation based on mouse position
        //End of tutorial-based code

        if (Input.GetKey(KeyCode.R)) //if r is pressed
        {
            SceneManager.LoadScene("SlowBullets"); //reload level
        }

    }
}
