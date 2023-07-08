using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool dashing = false;
    [SerializeField] float dashing_time;
    [SerializeField] float colldown_dashing_time;
    Vector3 movement;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        dash();
        //Debug.Log(rb.velocity);
    }

    void move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (dashing)
        {
            dashing_time += Time.deltaTime;
            rb.velocity = new Vector3(movement.x * speed * 5, 0, movement.y * speed * 5);
            if (dashing_time >= 0.2f)
            {
                dashing = false;
                dashing_time = 0f;
            }
        }
        else
        {
            colldown_dashing_time += Time.deltaTime;
            rb.velocity = new Vector3(movement.x * speed, 0, movement.y * speed);
        }
    }

    void dash()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!dashing && colldown_dashing_time >= 1f)
            {
                colldown_dashing_time = 0;
                dashing = true;
            }
        }
    }
}
