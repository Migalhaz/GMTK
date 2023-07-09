using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public bool canShot;
    public bool canShotForever;
    public bool canTeleport;
    public bool canTeleportForever;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spear"))
        {
            collision.transform.position = new Vector3(1, 1, 1) * -100;
            canShot = true;
            canTeleport = false;
        }

    }
}
