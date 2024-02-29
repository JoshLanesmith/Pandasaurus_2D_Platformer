using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling, doubleJump, swiping }
    private bool isSwiping = false;

    [SerializeField] private AudioSource jumpSoundEffect;

    public bool IsSwiping { get => isSwiping; }

    private int jumps = 0;

    // for dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f; // the speed of Dash.
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f; // the cooldown time before Dash can be used again.
    [SerializeField] private TrailRenderer tr; // It is used to render the trail left behind the player during Dash.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        // It checks if the character is currently dashing.
        if (isDashing)
        {
            // It immediately returns so that it pauses any other actions while dashing.
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && (IsGrounded() || jumps < 1))
        {
            jumps++;
            //jumpSoundEffect.Play();
            if(AudioManager.Instance != null) AudioManager.Instance.PlaySFX("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSwiping = true;
        }
        if (IsGrounded())
        {
            jumps = 0;
        }
        

        UpdateAnimationState();

        // If the player presses the LeftControl key and Dash is available, it starts the Dash coroutine.
        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (isSwiping)
        {
            state = MovementState.swiping;
        }
        else
        {
            if (dirX > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }


            if (rb.velocity.y > .1f)
            {
                if (jumps == 0)
                {
                    state = MovementState.jumping;
                }
                else
                {
                    state = MovementState.doubleJump;
                }
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }

        }
        

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void FinishSwiping()
    {
        isSwiping = false;
    }

    private IEnumerator Dash()
    {
        canDash = false; // When Dash starts, it prevents Dash from being used again.
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;  // During Dash, it sets the gravity scale to 0 to prevent the effect of gravity.
        rb.velocity = new Vector2(dirX * dashingPower, 0f); // It sets the player's velocity to the Dash speed.
        tr.emitting = true; // It starts rendering the trail.
        /* Yield instructions are a key part of coroutines in Unity. 
        They allow the function to pause its execution here and resume on the next frame or after a certain amount of time.*/
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown); // It waits for the cooldown time of Dash.
        canDash = true; // Dash becomes available again.
    }
}
