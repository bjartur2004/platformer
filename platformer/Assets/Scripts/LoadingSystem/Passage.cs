using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{

    public string PassageName;

    [SerializeField] public sceneManager SM;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SM.GoThroughPassage(PassageName);
        }
    }
}
