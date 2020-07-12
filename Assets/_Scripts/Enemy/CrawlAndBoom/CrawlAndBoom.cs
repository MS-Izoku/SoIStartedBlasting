using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
public class CrawlAndBoom : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private GameObject corpseBoom;

    Animator anim;
    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        DistanceCheck();
    }

    private void DistanceCheck()
    {
        if (anim.GetFloat("Health") > 0)
        {
            agent.destination = PlayerController.PlayerBody.transform.position;

            if (Vector3.Distance(this.transform.position, PlayerController.PlayerBody.transform.position) < 2)
            {
                this.gameObject.GetComponent<Animator>().SetFloat("Health", 0);
                Instantiate(corpseBoom, this.transform.position, this.transform.rotation);                
            }
        }
                 
    }

    


}
