using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    void Start()
    {
        Shoting();
    }

    void Shoting()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Physics.IgnoreCollision(GetComponent<Collider>(), newBullet.GetComponent<Collider>());
    }
}
