using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiraBricks : MonoBehaviour
{
    [SerializeField] float m_direction;
    [SerializeField] float m_rotateSpeed;
    float m_currentSpeed;
    Vector3 m_eulerAngles;
    void Update()
    {
        m_currentSpeed += m_rotateSpeed * m_direction;
        m_eulerAngles.Set(transform.eulerAngles.x, m_currentSpeed, transform.eulerAngles.z);
        m_currentSpeed = m_eulerAngles.y;
        transform.eulerAngles = m_eulerAngles;
    }
}
