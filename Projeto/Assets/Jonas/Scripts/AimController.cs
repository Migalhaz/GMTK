using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class AimController : MonoBehaviour
{
    [SerializeField] Vector3[,] aimSpot = { 
        { new Vector3(0, 0), new Vector3(0, 0), new Vector3(0, 0), },
        { new Vector3(0, 0), new Vector3(0, 0), new Vector3(0, 0), },
        { new Vector3(0, 0), new Vector3(0, 0), new Vector3(0, 0), },
    };
    Vector3 position;
    
    int inputX;
    int inputY;
    GameObject bulletInstance;
    [SerializeField, Min(1)]float bulletSpeed;
    [SerializeField] GameObject player;

    [Header("FireLoad Attributes")]
    [SerializeField] GameObject spear;

    [Header("FireLoad Attributes")]
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    public bool isLoading;

    private void Update()
    {
        inputX = (int)Input.GetAxisRaw("Horizontal");
        inputY = (int)Input.GetAxisRaw("Vertical");
        Debug.Log("Spot retornado: " + GetSpot());

        if (Input.GetKeyDown(KeyCode.C))
        {
            Fire(maxSpeed);
        }
    }

    
    public Vector3 GetSpot()
    {
        position = transform.position;
        aimSpot[0, 0] = new Vector3(position.x - 0.9f, position.y, position.z - 0.9f);
        aimSpot[1, 0] = new Vector3(position.x, position.y, position.z - 1);
        aimSpot[2, 0] = new Vector3(position.x + 1, position.y, position.z - 1);
        aimSpot[0, 1] = new Vector3(position.x - 1, position.y, position.z);
        aimSpot[1, 1] = new Vector3(position.x, position.y, position.z);
        aimSpot[2, 1] = new Vector3(position.x + 1, position.y, position.z);
        aimSpot[0, 2] = new Vector3(position.x - 1, position.y, position.z + 1);
        aimSpot[1, 2] = new Vector3(position.x, position.y, position.z + 1);
        aimSpot[2, 2] = new Vector3(position.x + 1, position.y, position.z + 1);

        return aimSpot[inputX +1, inputY + 1];
    }

    void Fire(float bulletSpeed)
    {
        spear.transform.position = GetSpot();
        Physics.IgnoreCollision(GetComponentInParent<Collider>(), spear.GetComponent<Collider>());

        if(inputX == 0 && inputY == 0)
        {
            spear.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -bulletSpeed);
        }
        else
        {
            spear.GetComponent<Rigidbody>().velocity = new Vector3(inputX * bulletSpeed, 0, inputY * bulletSpeed);
        }
         
    }

    float LoadFire()
    {
        float finalSpeed = minSpeed;
        while (Input.GetKeyDown(KeyCode.C))
        {
            isLoading = true;
            finalSpeed++;
        }
        return finalSpeed;
    }

}
