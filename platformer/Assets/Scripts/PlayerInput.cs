using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // player input sér um að taka við taka input og senda á viðeigandi aðgerð

    private playerMotor pMotor;


    // Start is called before the first frame update
    void Start()
    {
        pMotor = gameObject.GetComponent<playerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.D) == false)
        {
            pMotor.move(-1);
        }
        else if (Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.A) == false)
        {
            pMotor.move(1);
        }
        else
        {
            pMotor.move(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pMotor.jump();
        }

    }
}
