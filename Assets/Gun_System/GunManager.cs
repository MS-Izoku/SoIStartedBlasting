using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GunPickup gunPickupPrefab;
    public List<GameObject> gunsInScene = new List<GameObject>();
    public static GunManager instance;

    private void Awake()
    {
        instance = this;
        if(transform.childCount == 0)
        {
            CreateGuns();
        }
    }

    public void CreatePickup(GameObject gunObj)
    {
        GunPickup item = Instantiate(gunPickupPrefab).GetComponent<GunPickup>();
        item.transform.position = RandomlySpawnOnNavMesh.RandomPoint();
        item.gunObj = gunObj.gameObject;
    }


    private void CreateGuns()
    {
        for (int i = 0; i < gunsInScene.Count; i++)
        {
            GameObject inGameWeapon = Instantiate(gunsInScene[i], transform);
            
            CreatePickup(inGameWeapon);
            inGameWeapon.SetActive(false);
        }
    }

    public static void ReturnGun(GunObject gunObj)
    {
        IEnumerator WaitForBulletsToReturn() {
            Debug.Log("Waiting For Bullets to Return before Returning");
          
            Debug.Log("All Bullets have Returned");
            Transform gun = ShootingController.currentGun.transform;
            gun.GetComponent<GunObject>().ammoPool.ReturnAllBullets();
            while (gunObj.ammoPool.transform.childCount != gunObj.ammoPool.allBullets.Count) // while gunObj doesn't have all bullets
            {
                instance.CreatePickup(gunObj.gameObject);
                yield return null;
            }

            gunObj.clipSize = gunObj.maxClipSize;

            gun.SetParent(GunManager.instance.transform);
            gun.gameObject.SetActive(false);

            instance.CreatePickup(gunObj.gameObject);
            yield return null;

            
        }

        instance.StartCoroutine(WaitForBulletsToReturn());
 
    }
}
