using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

    public class PlayerManager : MonoBehaviour
    {
    [Header("Player Attributes")]
    [SerializeField] float m_speed;
        [SerializeField] bool isIdle = true;
        Rigidbody rb;
        Vector3 m_moveDir;
        Animator anim;

        

    [Header("Player Dash")]
    [SerializeField] float speedDash;
    [SerializeField] bool dashing = false;
    [SerializeField] float dashing_time;
    [SerializeField] float colldown_dashing_time;


    private void Awake()
    {
        anim ??= GetComponent<Animator>();
    }

    private void Start()
    {
        rb ??= GetComponent<Rigidbody>();

    }

    private void Update()
    {
        m_moveDir.Set(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));
        //print(lastInputX + lastInputZ);
        move();
        if (IsMoving())
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }
        dash();
        updateAnims();
        
    }

    private bool IsMoving()
    {
        //Debug.Log("velocity: "+ rb.velocity);
        return rb.velocity == Vector3.zero;
    }

    private void updateAnims()
    {
        anim.SetFloat("inputX", m_moveDir.x);
        anim.SetFloat("inputZ", m_moveDir.z);
        anim.SetBool("isIdle", isIdle);
    }

    void move()
    {
        if (dashing)
        {
            isIdle = false;
            dashing_time += Time.deltaTime;
            rb.velocity = m_moveDir.normalized * speedDash * m_speed;
            if (dashing_time >= 0.2f)
            {
                dashing = false;
                dashing_time = 0f;
            }
        }
        else
        {
            colldown_dashing_time += Time.deltaTime;
            rb.velocity = m_moveDir * m_speed;
                       
        }
    }

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!dashing && colldown_dashing_time >= 1f)
            {
                colldown_dashing_time = 0;
                dashing = true;
            }
        }
    }
}