using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();   
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw ("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce (Vector2.up * 400f);  
    }

    void FixedUpdate ()
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = col.transform;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }
}
