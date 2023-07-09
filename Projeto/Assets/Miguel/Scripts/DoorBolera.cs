using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBolera : MonoBehaviour
{
    Transform player;
    [SerializeField] CameraController cameraController;
    [SerializeField] Transform playerSpawnPoint;
    [SerializeField] Transform playerExitPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnterMap();
        }
    }

    void EnterMap()
    {
        player.position = playerSpawnPoint.position;
        cameraController.ForceCamPosition();

    }

    public void ExitMap()
    {
        player.position = playerExitPoint.position;
        cameraController.ForceCamPosition();
    }
}
