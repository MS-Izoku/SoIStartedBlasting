using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class blocker : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (anim.GetFloat("Health") > 0)
        {
            agent.destination = PlayerController.PlayerBody.transform.position;
        }
    }
}
