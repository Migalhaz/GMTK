using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoleraScript : BossAbstract
{
    [SerializeField] Transform m_player;
    [SerializeField] float m_moveSpeed;
    [SerializeField] float m_rotateSpeed;
    [SerializeField] Transform m_model;
    float m_currentAngle;
    [SerializeField] Vector4 m_planePosition;
    [SerializeField] GameObject m_semNucleo;

    void Start()
    {
        m_player ??= GameObject.FindGameObjectWithTag("Player").transform;
        SetLookDirection();
    }

    public void Setup(Vector3 size)
    {
        transform.localScale = size;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        m_currentAngle += m_rotateSpeed;
        m_model.eulerAngles = m_currentAngle * Vector3.one;
        transform.Translate(m_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Teste ");
        SetLookDirection();
    }

    public void SetLookDirection()
    {
        //Vector3 target = new(m_player.position.x, transform.position.y, m_player.position.z);

        float posX = Random.Range(m_planePosition.x, m_planePosition.y);
        float posZ = Random.Range(m_planePosition.z, m_planePosition.w);
        Vector3 target = new(posX, transform.position.y, posZ);
        transform.LookAt(target);
    }

    [ContextMenu("Damage")]
    public override void Damage()
    {
        BoleraScript novaBola = Instantiate(m_semNucleo, transform.position, Quaternion.identity).GetComponent<BoleraScript>();
        novaBola.Setup(transform.localScale * 0.5f);
        transform.localScale *= 0.5f;
    }
}
