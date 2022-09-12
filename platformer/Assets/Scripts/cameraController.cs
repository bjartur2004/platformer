using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // sér um að hreifa myndavélina á réttan stað

    public Transform target;
    public Vector2 offset;
    

    [SerializeField] private float playGive;
    [SerializeField] private float maxGive;

    private Vector2 goTarget;
    private Vector2 error = new Vector2 (0,0);
    private Vector2 correction = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position.Set(target.position.x + offset.x, target.position.y + offset.y, -10);
    }

    // Update is called once per frame, after update
    void FixedUpdate()
    {
        goTarget.Set(target.position.x + offset.x, target.position.y + offset.y);
        error = goTarget - new Vector2(transform.position.x, transform.position.y);

        correction.x = error.x * Mathf.Clamp(Mathf.Abs(error.x * (1 / maxGive)), 0, 1);
        correction.y = error.y * Mathf.Clamp(Mathf.Abs(error.y * (1 / maxGive)), 0, 1);


        transform.Translate(correction);

    }
}
