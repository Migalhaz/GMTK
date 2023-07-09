using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] BossAbstract bossScript;
    [SerializeField] Portas m_portas;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        bossScript.SetActive(true);
        m_portas.Close();
    }
}
