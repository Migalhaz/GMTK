using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerManager : MonoBehaviour
    {
        [Header("Player Attributes")]
        [SerializeField]float m_speed;

        Rigidbody rb;
        Vector3 m_moveDir;

    private void Start()
    {
        rb ??= GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = m_moveDir * m_speed;
    }

    private void Update()
    {
        m_moveDir.Set(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));
    }
}