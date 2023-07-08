using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] VisualEffect effect;
    float arco;
    

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        arco += speed;
        if (arco >= 1) arco = 0;
        effect.SetFloat("Arco", arco);
    }
}
