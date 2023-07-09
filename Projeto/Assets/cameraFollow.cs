using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
