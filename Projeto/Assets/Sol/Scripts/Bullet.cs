using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] VisualEffect effect;
    float arco;
    Rigidbody rb;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        arco += speed;
        if (arco >= 1) { 
            arco = 0;
            rb.velocity = new Vector3(0, 0, 0);
        }
        effect.SetFloat("Arco", arco);
    }
}
