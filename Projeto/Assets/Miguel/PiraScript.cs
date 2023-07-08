using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiraScript : BossAbstract
{
    [Header("Attack Settings")]
    [SerializeField] List<GameObject> m_attackRay;
    bool m_isAttacking;
    [SerializeField, Min(0)] float m_attackDelay;

    [Header("Rotate Settings")]
    [SerializeField] Vector2 m_rangeTimer;
    [SerializeField, Min(0)] float m_rotateSpeed;
    float m_currentSpeed;
    float m_currentTimer;
    Vector3 m_eulerAngles;

    private void Awake()
    {
        SetCurrentTimer();
        SetRayActive(false);
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
        StartCoroutine(nameof(AttackEffect));
    }

    IEnumerator AttackEffect()
    {
        m_isAttacking = true;
        m_canTakeDamage = true;
        yield return new WaitForSeconds(m_attackDelay * 0.5f);
        SetRayActive(true);
        yield return new WaitForSeconds(m_attackDelay * 0.5f);
        SetRayActive(false);
        m_isAttacking = false;
        m_canTakeDamage = false;
        SetCurrentTimer();
    }

    void SetRayActive(bool active)
    {
        foreach (GameObject ray in m_attackRay)
        {
            ray.SetActive(active);
        }
    }

    void SetCurrentTimer()
    {
        m_currentTimer = Random.Range(m_rangeTimer.x, m_rangeTimer.y);
    }
}
