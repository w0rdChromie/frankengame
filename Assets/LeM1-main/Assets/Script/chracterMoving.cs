using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chracterMoving : MonoBehaviour
{
    public Rigidbody2D characterRB;
    public float characterspeed = 3f;
  
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        characterRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * characterspeed;
    }


    private void OnCollisionEnter2D(Collision2D targetPlayer)
    {
        if (targetPlayer.gameObject.tag == "YellowCoin")
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            Destroy(targetPlayer.gameObject);
            transform.localScale += new Vector3(1.0f,1.0f,1.0f);

        }

        else if (targetPlayer.gameObject.tag == "RedCoin")
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Destroy(targetPlayer.gameObject);
            transform.localScale -= new Vector3(1.8f,1.8f,1.8f);
        }

        else if (targetPlayer.gameObject.tag == "BlueCoin")
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            Destroy(targetPlayer.gameObject);
            transform.localScale += new Vector3(2.5f,2.5f,2.5f);
        }

       


    }
}
