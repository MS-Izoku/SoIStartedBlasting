using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GunPickup : GetTriggerFromChild
{
    public GameObject gunObj;

    public override void DoEffect(Collider other)
    {
       if(gunObj != null)
        {
            gunObj.gameObject.SetActive(true);
            other.transform.GetComponent<ShootingController>().EquipGun(gunObj.GetComponent<GunObject>());
            gameObject.SetActive(false);
        }
    }
}
