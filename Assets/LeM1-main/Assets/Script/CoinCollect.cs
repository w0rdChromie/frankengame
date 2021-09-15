using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    //Color yCoin = color.yellow;


    //public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D targetPlayer)
    {
       

        Destroy(this.gameObject);
   
    }


}
