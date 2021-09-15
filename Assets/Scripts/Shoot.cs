using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet; //makes slot for bullet prefab
    private Vector2 myLocation; //makes Vector 2 for bullet position
                                

    public Quaternion shootRot; // Saves the transform.rotation to a variable


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var objectPos = Camera.main.WorldToScreenPoint(transform.position);

        var dir = Input.mousePosition - objectPos;


        shootRot = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));

        if (Input.GetKeyDown(KeyCode.Mouse0)) //if left mouse is pressed
        { 
            myLocation = gameObject.transform.position; //sets myLocation to player position

            Instantiate(bullet, new Vector2(myLocation.x, myLocation.y), shootRot); //makes new bullet at player location
        }
    }
}
