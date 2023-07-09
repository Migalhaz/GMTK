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

    private void OnCollisionEnter(Collision collision)
    {
        print("colidiu");
        if (!collision.gameObject.CompareTag("Spear")) return;
        print("com a bola");
        m_bossScript.Damage();
    }
}
