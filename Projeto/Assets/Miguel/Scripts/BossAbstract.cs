using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbstract : MonoBehaviour
{
    protected bool m_canTakeDamage;
    public virtual void Damage()
    {
        if (!m_canTakeDamage) return;
        Destroy(gameObject);
    }
}
