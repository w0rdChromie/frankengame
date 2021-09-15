using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Credit to blackthornprod for the inspiration for this code
public class enemyScript : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float shotPause;
    public float startPause;

    public GameObject projectile;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        shotPause = startPause;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (shotPause <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotPause = startPause;
        }
        else {
            shotPause -= Time.deltaTime;
        }
    }
}
