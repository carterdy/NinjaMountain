using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float move_accel = 4;
    public float jump_force = 4;

    private Rigidbody2D rb;
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}

    /* Call to make the character jump.  Jumping will fail if the character is in a position which does not allow them to jump.
        Current jumping behavior would allow for wall climbing    
    */
    void attemptJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jump_force);
        }
    }

    /* Called when this gameobject starts a collision with another */
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    /* Called when this gameobject stops colliding with another */
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

	void FixedUpdate () {
        float x_in = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * x_in * move_accel);
        if (Input.GetButton("Jump"))
        {
            attemptJump();
        }
	}
}
