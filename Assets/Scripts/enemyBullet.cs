using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Credit to blackthornprod for the inspiration for this code

public class enemyBullet : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("player")) {
            DestroyProjectile();
        }
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }
}
