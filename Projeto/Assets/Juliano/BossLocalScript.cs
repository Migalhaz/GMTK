using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLocalScript : MonoBehaviour
{
    public Transform local_player;
    public Transform local_boss;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = local_player.transform.position;
            Instantiate(boss, new Vector3(local_boss.transform.position.x,
                local_boss.transform.position.y,
                local_boss.transform.position.z), Quaternion.identity);
        }
    }
}
