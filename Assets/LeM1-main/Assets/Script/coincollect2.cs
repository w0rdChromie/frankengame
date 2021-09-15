using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollect2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D targetPlayer2)
    {
        if (targetPlayer2.gameObject.tag == "character")
        {
            targetPlayer2.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        Destroy(this.gameObject);

    }
}
