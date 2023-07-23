using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public GameObject Grandma;
    private bool hasGrandma = false;
    private bool spacekeydown = false;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping }
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        spacekeydown = Input.GetKeyDown("space");
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown("space")) {
            if (hasGrandma) {
                Instantiate(Grandma, transform.position, transform.rotation);
                hasGrandma = false;
            }
        }

        UpdateAnimation();

        
    }
    private void UpdateAnimation() {
        MovementState state;
        if (dirX > 0f) {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f) {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Pylon")) {
            moveSpeed = 1f; 
        }
        if (collision.gameObject.CompareTag("Grandma")) {
            if (spacekeydown && !hasGrandma) {
                //Debug.Log("yes");
                //Destroy(collision.gameObject);
                hasGrandma = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Pylon")) {
            moveSpeed = 7f; 
        }
    }

    private void OnCollisionStay2D(Collision2D collision) { 
        if (collision.gameObject.CompareTag("Grandma")) {
            Debug.Log("honk");
            if (Input.GetKey("space")) {
                hasGrandma = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) { 
        if (collision.gameObject.CompareTag("Grandma")) {
            if (Input.GetKeyDown("space")) {
                //Destroy(collision.gameObject);
                
                hasGrandma = true;
            }
        }
    }
}