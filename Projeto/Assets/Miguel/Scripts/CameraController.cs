using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform m_player;
    [SerializeField] Vector3 m_camPositionOffset;
    [SerializeField] Vector3 m_camRotation;
    [SerializeField, Range(0, 1f)] float m_deadZone;
    [SerializeField, Range(1, 10f)] float m_camSmothness;
    void Start()
    {
        m_player ??= GameObject.FindGameObjectWithTag("Player").transform;
        ForceCamPosition();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        LookAt();
    }

    void Move()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Mathf.Abs(input.magnitude) < m_deadZone)
        {
            return;
        }

        Vector3 position = Vector3.Lerp(transform.position, m_player.position + m_camPositionOffset, m_camSmothness * Time.deltaTime);
        transform.position = position;
    }

    public void ForceCamPosition()
    {
        transform.position = m_player.position + m_camPositionOffset;
    }

    void LookAt()
    {
        transform.eulerAngles = m_camRotation;
    }
}
