using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbstract : MonoBehaviour
{
    public virtual void Damage()
    {
        Destroy(gameObject);
    }
}
