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

    private Rigidbody rig;
    void Start()
    {
        m_player ??= GameObject.FindGameObjectWithTag("Player").transform;
        SetLookDirection();
        TryGetComponent(out rig);
    }

    public void Setup(Vector3 size)
    {
        transform.localScale = size;
    }

    void Update()
    {
        RotationAnim();
        MovePhysics();
        //Move();
    }
   void RotationAnim()
    {
        m_currentAngle += m_rotateSpeed;
        m_model.eulerAngles = m_currentAngle * Vector3.one;
    }

    void MovePhysics()
    {
        rig.velocity = (m_moveSpeed * Time.deltaTime * transform.forward);
    }

    void Move()
    {
        m_currentAngle += m_rotateSpeed;
        m_model.eulerAngles = m_currentAngle * Vector3.one;
        transform.Translate(m_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Teste ");
        SetLookDirection();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Teste ");
        rig.velocity = Vector3.zero;

        ContactPoint point = collision.GetContact(0);

        Vector3 forw = transform.forward;
        Vector3 mirrored = Vector3.Reflect(forw, point.normal);
        transform.rotation = Quaternion.LookRotation(mirrored, transform.up);

        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));
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
