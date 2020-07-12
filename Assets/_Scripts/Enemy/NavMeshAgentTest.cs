using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshAgentTest : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent.destination = marker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
