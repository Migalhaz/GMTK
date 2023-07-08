using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimController : MonoBehaviour
{
    [SerializeField] Vector3[,] aimSpot = { 
        { new Vector3(0, 0), new Vector3(0, 0), new Vector3(0, 0), },
        { new Vector3(0, 0), new Vector3(0, 0), new Vector3(0, 0), },
        { new Vector3(0, 0), new Vector3(0, 0), new Vector3(0, 0), },
    };
    [SerializeField] GameObject player;

    Vector3 moveDir;
    Vector3 position;
    int inputX;
    int inputY;

    private void Start()
    {
        position = transform.position;
        aimSpot[0, 0] = new Vector3(position.x -1 , position.y, position.z - 1);
        aimSpot[1, 0] = new Vector3(position.x, position.y, position.z - 1);
        aimSpot[2, 0] = new Vector3(position.x + 1, position.y, position.z - 1);
        aimSpot[0, 1] = new Vector3(position.x - 1, position.y, position.z);
        aimSpot[1, 1] = new Vector3(position.x, position.y, position.z);
        aimSpot[2, 1] = new Vector3(position.x + 1, position.y, position.z);
        aimSpot[0, 2] = new Vector3(position.x - 1, position.y, position.z + 1);
        aimSpot[1, 2] = new Vector3(position.x, position.y, position.z + 1);
        aimSpot[2, 2] = new Vector3(position.x + 1, position.y, position.z + 1);
    }

    private void Update()
    {
        inputX = (int)Input.GetAxisRaw("Horizontal");
        inputY = (int)Input.GetAxisRaw("Vertical");
        Debug.Log("Spot retornado: " + GetSpot());
    }
    public Vector3 GetSpot()
    {            
        return aimSpot[inputX +1, inputY + 1];
    }


}
