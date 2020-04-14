using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public Fields

    // Private Fields
    private Rigidbody2D rb;
    private Camera gameCamera;
    private float movement = 0f;
    private float jumpSpeed = 8f;
    

    private Transform t;
    [SerializeField] [Range(1.0f, 10.0f)] private float speed = 5.0f;
    // Public Methods

    // Private Methods
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame - 60 per min
    void FixedUpdate()
    {
        //Keep player within these limits
        //float xValue = Mathf.clamp(value, min, max);
        //rb.position.x
        

        // get Movement
        // float vMovement = Input.GetAxis("Vertical");
        float movement = Input.GetAxis("Horizontal");

        if (movement > 0) {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
        else if (movement < 0) {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
 
        // Apply force 
        // Velocity = movement and speed
        rb.velocity = new Vector2(movement * speed, 0);
 
        // Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
            //rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //rb.velocity += jumpSpeed * Vector2.up;
            rb.AddForce(new Vector2(0, 100), ForceMode2D.Impulse); //Vector2(x,y)
        }

        // Clamps to prevent the player from going off screen on the 'x' axis
        float yValue = Mathf.Clamp(rb.position.y, -2.75f, 4.5f);
        float xValue = Mathf.Clamp(rb.position.x, -10.5f, 10.5f);
        rb.position = new Vector2(xValue, yValue);
    }

    private void Awake()
    {
        gameCamera = Camera.main;
    }
}
