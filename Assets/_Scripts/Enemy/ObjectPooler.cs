using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        
    }

    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            pool.tag = pool.prefab.tag.ToString();
            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            if(poolDictionary[tag].Count != 0)
            {
                GameObject objectToSpawn = poolDictionary[tag].Dequeue();
                objectToSpawn.SetActive(true);
                pos.y += 2;
                objectToSpawn.transform.position = pos;
                objectToSpawn.transform.rotation = rotation;

                return objectToSpawn;
            }
            return null;
        }
        else
            return null;       
    }

    public void AddBackToPool(GameObject returningObj, string tag)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            poolDictionary[tag].Enqueue(returningObj);
            returningObj.SetActive(false);
        }
    }
}
