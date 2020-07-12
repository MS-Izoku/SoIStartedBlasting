using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInputs;

public class ShootingController : MonoBehaviour
{

    public static Camera mainCam;   // the main camera attached to the player
    private Transform gunPoint; // the object the Gun-Prefab is attached to
    private Transform gunPrefabArea;    // the actual swappable part of the prefabs

    public bool useDefaultGun = false;
    public GunObject defaultGun; //used to set the default gun
    public static GunObject currentGun;
    private bool hasGunEquipped = false;

    void Start()
    {
        mainCam = Camera.main;
        GunUIManager.playerController = this.gameObject.transform.GetComponent<PlayerController>();
        gunPoint = mainCam.transform.Find("Gun Point");
        gunPrefabArea = gunPoint.Find("Gun Prefab Area");
        if(useDefaultGun) currentGun = defaultGun;
    }

    // equip a gun
    public void EquipGun(GunObject gunObj)
    {
        DropGun();
        AttachGunToPlayer(gunObj);
        currentGun = gunObj;
        hasGunEquipped = true;

        // for this project
        gunObj.StartCoroutine(gunObj.AutoShotRoutine());
    }

    public void AttachGunToPlayer(GunObject gunObj)
    {
        gunObj.transform.SetParent(gunPrefabArea);
        gunObj.transform.position = gunPrefabArea.position;
        gunObj.transform.rotation = gunPrefabArea.rotation;
    }

    //swap between guns
    public void SwapGun(GunObject gunObj)
    {
        // store the gun in the inventory
        EquipGun(gunObj);
    }

    //drops currently equipped gun
    public void DropGun()
    {
        Debug.Log(currentGun + " Before");
        if (hasGunEquipped)
        {
            if(currentGun.ammoCount > 0) GunManager.instance.CreatePickup(currentGun.gameObject);
            
            GunManager.ReturnGun(currentGun);
            currentGun = null;
            hasGunEquipped = false;
        }

        Debug.Log(currentGun + " After");
    }



    void Update()
    {
        if(currentGun != null)
            if (currentGun.clipSize <= 0)
                DropGun();

        if (PlayerInput.FireGun && hasGunEquipped)
        {
            currentGun.Shoot();
        }
            
    }
}
