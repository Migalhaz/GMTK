using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiraScript : BossAbstract
{
    [SerializeField] List<GameObject> m_attackRay;
    [SerializeField] Vector2 m_rangeTimer;
    [SerializeField, Min(0)] float m_rotateSpeed;
    [SerializeField, Min(0)] float m_attackDelay;
    float m_currentSpeed;
    float m_currentTimer;
    Vector3 m_eulerAngles;
    bool canTakeDamage;
    bool m_isAttacking;

    private void Awake()
    {
        SetCurrentTimer();
    }

    private void Update()
    {
        m_currentTimer -= Time.deltaTime;

        if (m_currentTimer > 0)
        {
            Rotate();
        }
        else
        {
            Attack();
        }
        
    }

    void Rotate()
    {
        m_currentSpeed += m_rotateSpeed;
        m_eulerAngles.Set(transform.eulerAngles.x, m_currentSpeed, transform.eulerAngles.z);
        transform.eulerAngles = m_eulerAngles;
    }

    void Attack()
    {
        if (m_isAttacking) return; 
        m_currentSpeed = 0f;
        StartCoroutine(nameof(AttackEffect));
    }

    IEnumerator AttackEffect()
    {
        m_isAttacking = true;
        canTakeDamage = true;
        yield return new WaitForSeconds(m_attackDelay);
        Debug.Log("Plou");
        m_isAttacking = false;
        canTakeDamage = false;
        SetCurrentTimer();
    }

    void SetCurrentTimer()
    {
        m_currentTimer = Random.Range(m_rangeTimer.x, m_rangeTimer.y);
    }


}
