using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomlySpawnOnNavMesh : MonoBehaviour
{
    public float radius = 200f;
    public static RandomlySpawnOnNavMesh instance;
    private static float Radius;

    private void Awake()
    {
        instance = this;
        RandomlySpawnOnNavMesh.Radius = radius;
    }

    public static Vector3 RandomPoint()
    {
        /*
        NavMeshHit hit;
        //NavMesh.SamplePosition(Random.insideUnitSphere * RandomlySpawnOnNavMesh.Radius, out hit, RandomlySpawnOnNavMesh.Radius, 1);
        Vector3 location = Random.insideUnitSphere * 30;
        NavMesh.SamplePosition(location, out hit, 10, 1);
        Debug.Log(hit.position);
        */
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);
            return new Vector3(x, 10, z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
