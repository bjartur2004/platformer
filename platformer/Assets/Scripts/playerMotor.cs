using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotor : MonoBehaviour
{
    // player motor sér um að hreyfa pleyerinn, halda utanum movement states og gera tékks

    private Rigidbody2D rb;

    // config variables
    [SerializeField] private float gravityScale;
    [Space(10)]
    [SerializeField] private float moveForce;
    [SerializeField] private float speedRampSpeed;
    [SerializeField] private float maxSpeedRamp;
    [Space(10)]
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxHold;
    [SerializeField] private float jumpingGravity;
    [Space(10)]
    [SerializeField] private float verticalDrag;
    [SerializeField] private float horazontalDrag;
    [Space(10)]
    [SerializeField] private float ungroundTime;


    // process variables
    private float speedRamp = 0;
    private float speedRampForce = 1;

    private bool isjumping;
    private float holdTimer;
    private bool grounded;

    private float verticalDragReduction;
    private float horazontalDragReduction;

    private bool isUngrounding;
    private float ungroundTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.gravityScale = gravityScale;

        verticalDragReduction = Mathf.Pow(2, -verticalDrag);
        horazontalDragReduction = Mathf.Pow(2, -horazontalDrag);

    }

    // Update is called once per frame
    void Update()
    {
        if (isjumping)
        {
            jumping();
        }
        if (isUngrounding)
        {
            ungrounding();
        }
    }

    private void FixedUpdate()
    {
        drag();
    }

    private void drag()
    {
        rb.velocity = new Vector2(rb.velocity.x * horazontalDragReduction, rb.velocity.y * verticalDragReduction);
    }

    public void move(float dir)
    {
        // reset speed rampup
        if(Mathf.Sign(rb.velocity.x) != Mathf.Sign(dir)){
            speedRamp = 0;
        }
        else // ramp speed and constrain to max
        {
            if(speedRamp < 1 && dir != 0)
            {
                speedRamp += speedRampSpeed * Time.deltaTime;
                if(speedRamp > 1)
                {
                    speedRamp = 1;
                }

                // smooth ramp up 
                speedRampForce = 1 + speedRamp * (1 + speedRamp * (1 - speedRamp)) * maxSpeedRamp;
            }
        }
        // seta x hraða 
        rb.velocity = new Vector2 (dir * moveForce * speedRampForce, rb.velocity.y);
    }

    public void onGround(bool onGround)
    {
        if(onGround)
        {
            grounded = true;
        }
        else
        {
            if(isjumping == false)
            {
                ungroundTimer = ungroundTime;
                isUngrounding = true;
            }
            else
            {
                grounded = false;
            }

        }
    }

    public void jump(bool start)
    {
        if (start && grounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.gravityScale = jumpingGravity;
            holdTimer = maxHold;
            isjumping = true;
        }
        else
        {
            if (isjumping)
            {
                isjumping = false;
                rb.gravityScale = gravityScale;
            }
        }
    }


    private void jumping()
    {
        holdTimer -= Time.deltaTime;
        if(holdTimer < 0)
        {
            isjumping = false;
            rb.gravityScale = gravityScale;
        }
    }

    private void ungrounding()
    {
        ungroundTimer -= Time.deltaTime;
        if(ungroundTimer < 0)
        {
            isUngrounding = false;
            grounded = false;
        }
    }




}
