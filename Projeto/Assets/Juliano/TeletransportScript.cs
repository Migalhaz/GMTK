using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportScript : MonoBehaviour
{
    [SerializeField] private GameObject lance;
    [SerializeField] public static bool lance_field = false;

    public PlayerCollider pc;
    CameraController cameraController;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (lance_field)
            {
                if (!pc.canTeleportForever && !pc.canTeleport) return;
                transform.position = new Vector3(lance.transform.position.x,
                    lance.transform.position.y,lance.transform.position.z);
                cameraController.ForceCamPosition();
                //Destroy(lance);
                lance.SetActive(false);
                lance_field = false;
            }
        }
    }
}
