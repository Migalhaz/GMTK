using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelChild : MonoBehaviour
{
    Angel m_angel;
    void Awake()
    {
        m_angel = GetComponentInParent<Angel>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Death();
    }

    [ContextMenu("Kill Me")]
    public void Death()
    {
        m_angel.KillChild(gameObject);

    }

}
