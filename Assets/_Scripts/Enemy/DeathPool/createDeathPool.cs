using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createDeathPool : MonoBehaviour
{
    public GameObject deathPool;

    public void CreatePool()
    {
        Instantiate(deathPool, this.transform.position, this.transform.rotation);
    }
}
