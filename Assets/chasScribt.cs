using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class chasScribt : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;    
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    float destance = Vector3.Distance(agent.transform.position, target.position);
    //    if(destance<10)
    //    {
    //        agent.SetDestination(target.position);
    //    }
    //}
}
