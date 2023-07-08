using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathColllider : MonoBehaviour
{
    [SerializeField] BossAbstract m_bossScript;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Spear")) return;

        m_bossScript.Damage();
    }

}
