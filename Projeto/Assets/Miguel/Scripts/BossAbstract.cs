using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbstract : MonoBehaviour
{
    protected bool m_alive;
    protected bool m_canTakeDamage;
    protected bool m_active;

    public virtual void SetActive(bool active)
    {
        m_active = active;
        m_alive = m_active;
    }
    public virtual void Damage()
    {
        if (!m_canTakeDamage) return;
        m_alive = false;
        Destroy(gameObject);
    }
}
