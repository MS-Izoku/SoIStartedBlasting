using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LauncherMove : MonoBehaviour
{
    private float shots = 0;
    private float getPointRadius = 5;
    public GameObject bullet;
    public NavMeshAgent agent;
    private bool shoot = false;

    public float shotDelay = 3f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shots == 0)
        {
            agent.SetDestination(getDestination());
            shots = 3;
        }
        if(agent.remainingDistance < 2 && !agent.pathPending && shoot == false)
        {
            
            shoot = true;
        }
        if (shoot)
        {
            FireShot();           
        }

    }

    private Vector3 getDestination()
    {
        Vector3 location = Random.insideUnitSphere * getPointRadius;
        location += PlayerController.PlayerBody.transform.position;
        Vector3 finalPos = PlayerController.PlayerBody.transform.position;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(location, out hit, getPointRadius, 1))
        {
            finalPos = hit.position;            
        }
        return finalPos;
    }

    private void FireShot()
    {
        shotDelay -= Time.deltaTime;
        if(shotDelay < 0)
        {
            shots -= 1;
            GameObject acidBall = Instantiate(bullet);
            acidBall.transform.position = this.transform.position;
            acidBall.transform.position += new Vector3(0, 1, 0);
            acidBall.transform.LookAt(PlayerController.PlayerBody.transform.position);
            Vector3 temp = acidBall.transform.eulerAngles;
            temp.x = 0;
            temp.z = 0;
            acidBall.transform.eulerAngles = temp;
            shotDelay = 3;
        }
        
    }
}


