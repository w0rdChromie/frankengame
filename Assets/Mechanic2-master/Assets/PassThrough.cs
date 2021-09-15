using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThrough : MonoBehaviour
{
    float Cooldown = 0.5f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Cooldown;
        GetComponent<CircleCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X) && timer <= 0)
        {
            StartCoroutine(MoveThrough());

            timer = Cooldown;
        }

    }

    public IEnumerator MoveThrough()
    {
        //This is a Coroutine that triggers the box collider to turn off for a brief period
        GetComponent<CircleCollider2D>().enabled = false;

        
        yield return new WaitForSeconds(.5f);
        
        GetComponent<CircleCollider2D>().enabled = true;

    }
}

//Coroutine logic is based on an attack script from an old project of mine. It's essentially flipped to turn off colliders rather than on //