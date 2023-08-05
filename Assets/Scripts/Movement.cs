using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 directionMove;

    [SerializedField]
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(input.GetAxisRaw("Horizontal"), input.GetAxisRaw("Vertical"));

        //X
        if (input.x > 0.1f)
        {
            directionMove.x = 1f;
        }
        else if (input.x < 0.1f)
        {
            directionMove.x = -1f;
        }
        else
        {
            directionMove.x = 0f;
        }

        //Y
        if (input.y > 0.1f)
        {
            directionMove.y = 1f;
        }
        else if (input.y < 0.1f)
        {
            directionMove.y = -1f;
        }
        else
        {
            directionMove.y = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + directionMove * speed * Time.fixedDeltaTime);
    }
}
