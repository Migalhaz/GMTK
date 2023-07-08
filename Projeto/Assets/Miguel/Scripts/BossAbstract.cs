using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbstract : MonoBehaviour
{
    protected bool m_canTakeDamage;
    protected bool m_active;

    void SetActive(bool active)
    {
        m_active = active;
    }
    public virtual void Damage()
    {
        if (!m_canTakeDamage) return;
        Destroy(gameObject);
    }
}
