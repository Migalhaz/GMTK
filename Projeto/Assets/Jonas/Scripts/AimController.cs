using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal.Internal;
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
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] float loadingSpeed;
    [SerializeField] float loadingTime;
    [SerializeField] bool isLoading;
    [SerializeField] float speedBase;
    [SerializeField] int speedReduce;


    private void Update()
    {
        inputX = (int)Input.GetAxisRaw("Horizontal");
        inputY = (int)Input.GetAxisRaw("Vertical");
        

        if(Input.GetKey(KeyCode.Space))
        {
            isLoading = true;
            
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                isLoading = false;
                if (loadingTime > minTime)
                {                  
                    ForceReverse();
                    Fire(loadingTime);
                    
                }                               
                loadingTime = 0;
                
            }
            
        }

        transform.parent.LookAt(GetSpot());
    }

    private void FixedUpdate()
    {
        if(isLoading)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (loadingTime < maxTime)
            {
                loadingTime += loadingSpeed;
            }
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
        if (isLoading) { return; }
        spear.transform.position = GetSpot();
        spear.transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, 0);
        spear.SetActive(true);
        TeletransportScript.lance_field = true;
        Physics.IgnoreCollision(GetComponentInParent<Collider>(), spear.GetComponent<Collider>());

        if(inputX == 0 && inputY == 0)
        {
            spear.GetComponent<Rigidbody>().velocity = Vector3.zero;
            spear.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -bulletSpeed * speedBase),ForceMode.Impulse);
        }
        else
        {
            
            spear.GetComponent<Rigidbody>().velocity = Vector3.zero;
            spear.GetComponent<Rigidbody>().AddForce(new Vector3(inputX * bulletSpeed * speedBase, 0, inputY * bulletSpeed * speedBase), ForceMode.Impulse);
        }
         
    }

    void ForceReverse()
    {
        Vector3 reverseSpeed = spear.GetComponent<Rigidbody>().velocity;

        spear.GetComponent<Rigidbody>().AddForce(reverseSpeed/speedReduce, ForceMode.Impulse);
        Debug.Log(reverseSpeed);
    }
}
