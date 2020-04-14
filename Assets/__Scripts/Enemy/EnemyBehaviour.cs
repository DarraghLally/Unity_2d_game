using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// move left when things start

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour
{
    // == private fields ==
    [SerializeField] private float speed = 4.0f;

    private Rigidbody2D rb;

    // == private methods ==
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-1 * speed, 0);
        float yValue = Mathf.Clamp(rb.position.y, -2.75f, 4.5f);
        float xValue = Mathf.Clamp(rb.position.x, -10.5f, 10.5f);
        rb.position = new Vector2(xValue, yValue);
    }
}
