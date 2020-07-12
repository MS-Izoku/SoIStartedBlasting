using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDamage : MonoBehaviour
{
    float checkTime = .4f;
    void Update()
    {
        checkTime -= Time.deltaTime;
        if(checkTime < 0)
        {
            if(Vector3.Distance(PlayerController.PlayerBody.transform.position, this.transform.position) <= 3)
            {                
                PlayerHealth.Health(15);
                
            }
            Destroy(this.gameObject);
        }
    }
}
