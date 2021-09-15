using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float pSpeed;
    private Vector2 pVelocity;
    private Rigidbody2D rb2d;
    public Camera cam;

    private float reg = 1f;

    Vector2 movement;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        pVelocity = movementInput.normalized * pSpeed;

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {

        rb2d.MovePosition(rb2d.position + pVelocity * Time.fixedDeltaTime);

        Vector2 lookDir = mousePosition - rb2d.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D targetPlayer)
    {
        if (targetPlayer.gameObject.tag == "reset")
        {
            Destroy(targetPlayer.gameObject);
            transform.localScale = new Vector3(reg, reg, reg);
        }

        if (targetPlayer.gameObject.tag == "regBoost")
        {
            Destroy(targetPlayer.gameObject);
            transform.localScale += new Vector3(reg, reg, reg);
        }

        else if (targetPlayer.gameObject.tag == "negativeBoost")
        {
            Destroy(targetPlayer.gameObject);
            transform.localScale -= new Vector3(transform.localScale.x/2, transform.localScale.y/2, transform.localScale.z/2);
        }

        else if (targetPlayer.gameObject.tag == "majorBoost")
        {
            Destroy(targetPlayer.gameObject);
            transform.localScale += new Vector3(transform.localScale.x*2, transform.localScale.y*2, transform.localScale.z*2);
        }
    }
}
