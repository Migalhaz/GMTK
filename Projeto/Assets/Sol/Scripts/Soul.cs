using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soul : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField, Min(0.01f)] float reduceY;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
        if(agent.baseOffset >= player.transform.position.y)
        {
            agent.baseOffset -= reduceY;
        }


    }
}
