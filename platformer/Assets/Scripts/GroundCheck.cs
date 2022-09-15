using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private playerMotor player;

    private void Start()
    {
        player = transform.parent.GetComponent<playerMotor>();
    }

    void OnTriggerEnter2D()
    {
        player.onGround(true);
    }
    void OnTriggerExit2D()
    {
        player.onGround(false);
    }
}
