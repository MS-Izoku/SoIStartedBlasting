using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    public List<GameObject> allBullets = new List<GameObject>();
    public static AmmoPool CreateAmmoPool(GunObject parentObj)
    {
        Transform poolObj = new GameObject($"({parentObj.gunName}) Ammo Pool").transform;
        AmmoPool res = poolObj.gameObject.AddComponent(typeof(AmmoPool)) as AmmoPool;
        for (int i = 0; i < parentObj.ammoCount; i++)
        {
            GameObject bullet = Instantiate(parentObj.gunScriptableObj.bullet , poolObj);
            bullet.AddComponent<AmmoTag>();
            res.GetComponent<AmmoPool>().allBullets.Add(bullet);
            bullet.SetActive(false);
        }
        
        
        return res;
    }

    // Remove an Object from the pool, set its parent to another object to shoot
    // ie) move it from the pool position to the front of the barrel, then fire it off
    public static void Push(Transform newParent, Transform pool)
    {
        Transform targetObj = pool.transform.GetChild(0);
        targetObj.gameObject.SetActive(true);
        targetObj.SetParent(newParent);
    }

    public static void Push(Transform newParent, Transform pool , Vector3 position , Quaternion rotation)
    {
        Transform targetObj = pool.transform.GetChild(0);
        targetObj.gameObject.SetActive(true);
        targetObj.position = position;
        targetObj.rotation = rotation;
        targetObj.SetParent(newParent);
    }

    // Push an Object into the pool
    public static void Pull(Bullet bullet)
    {
        bullet.transform.SetParent(bullet.originalParent);
        bullet.gameObject.SetActive(false);
    }

    public void ReturnAllBullets()
    {
        for(int i = 0; i < allBullets.Count; i++)
        {
            AmmoPool.Pull(allBullets[i].GetComponent<Bullet>());
        }
    }

    public class AmmoTag : MonoBehaviour
    {
        public Transform showField;
        private Transform _originalParent;
        public Transform originalParent { get { return _originalParent; } }


        void Awake()
        {
            _originalParent = transform.parent;
            showField = originalParent;
        }
    }
}