using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotor : MonoBehaviour
{
    // player motor sér um að hreyfa pleyerinn, halda utanum movement states og gera tékks

    private Rigidbody2D rb;

    // config variables
    [SerializeField] private float moveForce;
    [SerializeField] private float speedRampSpeed;
    [SerializeField] private float maxSpeedRamp;
    [Space(10)]
    [SerializeField] private float jumpForce;



    // process variables
    private float speedRamp = 0;
    private float speedRampForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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


    public void jump()
    {
        rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
    }


}
