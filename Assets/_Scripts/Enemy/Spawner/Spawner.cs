using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoLevel;

public class Spawner : MonoBehaviour
{
    string[] enemies;
    
    private void Awake()
    {
        enemies = new string[3] { "Boom", "Blocker", "Launcher" };
        StartCoroutine("SpawnEnemy");
        transform.parent = null;
    }
    // Update is called once per frame
    private void OnEnable()
    {
        StartCoroutine("SpawnEnemy");
    }

    private float getSpawnTime()
    {
       return (LevelInfo.BaseSpawnSpeed + LevelInfo.Spawners) / LevelInfo.CurrentLevel;
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {            
            yield return new WaitForSeconds(getSpawnTime());
            SpawnUnit();
        }
    }

    public void SpawnUnit()
    {
        int rand = Random.Range(0, enemies.Length);
        ObjectPooler.Instance.SpawnFromPool(enemies[rand], this.transform.position, this.transform.rotation);
    }
}
