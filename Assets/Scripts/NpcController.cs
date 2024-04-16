using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NpcController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public int index;
    [SerializeField] Vector3 target;
    public TextMeshProUGUI estadoAtual;

    public int estados;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            estados++;
        }
    }

    public void UpdateDestination() 
    {
        target = waypoints[index].position;
        agent.SetDestination(target);
    }

    public void WaypointSelector() 
    {
        index++;
        if (index == waypoints.Length)
        {
            index = 0;
        }
    }
}
