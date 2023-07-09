using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoleraNucleo : BoleraScript
{
    int m_life = 5;
    public override void Damage()
    {
        base.Damage();
        m_life--;
        if (m_life <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Morreu");
    }


}
