using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//credit to Brackeys for the inspiration for this code
public class shootScript : MonoBehaviour
{
    public Transform bulletAim;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletAim.position, bulletAim.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletAim.up * bulletForce, ForceMode2D.Impulse);
        if (Input.GetMouseButton(1))
        {
            rb.drag = 10;
        }
    }
}
