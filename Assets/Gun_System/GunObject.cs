using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GunObject : MonoBehaviour
{
    public Gun gunScriptableObj;
    public FeedbackObject feedbackObj;
    [HideInInspector] 
    public string gunName;
    [HideInInspector] 
    public string description;
    [HideInInspector] 
    public int ammoCount;
    [HideInInspector] 
    public int clipSize;
    [HideInInspector]
    public int maxClipSize; // will track the original clip size of the gun
    [HideInInspector]
    public bool isAutomatic = false;

    private Transform shotPoint; // the position the projectile starts at
    private Transform handle; // the handle position, not sure if necessary as of yet

     public AmmoPool ammoPool;

    [HideInInspector] public Bullet bullet;
    
    // used for the Crosshairs
    // private Transform initialPosition;
    // private Transform aimPosition;

    [HideInInspector] public bool isShooting = false;


    void Awake()
    {
        shotPoint = transform.Find("Shot Point");
        handle = transform.Find("Handle Point");
        maxClipSize = gunScriptableObj.clipSize;

        SetupGun();
    }

    public void SetupGun()
    {
        ammoPool = AmmoPool.CreateAmmoPool(transform.GetComponent<GunObject>());
        gunName = gunScriptableObj.gunName;
        bullet = gunScriptableObj.bullet.GetComponent<Bullet>();
        description = gunScriptableObj.description;
        ammoCount = gunScriptableObj.ammoCount;
        clipSize = gunScriptableObj.clipSize;
        isAutomatic = gunScriptableObj.isAutomatic;
    }

    public void SwitchGun()
    {

    }


    public void Shoot(){
        if (clipSize <= 0)
        {
            Reload();
            return;
        }
        FireProjectile();
        isShooting = true;
        if (isAutomatic) StartCoroutine(AutoShotRoutine());
    }

    public void FireProjectile()
    {
        if (clipSize > 0)
        {
            clipSize--;
            AmmoPool.Push(null, ammoPool.transform , shotPoint.position , Quaternion.identity);
        }
    }

    public virtual void Reload(){
        if (clipSize != maxClipSize)
        {
            if (ammoCount - clipSize < 0 && ammoCount < maxClipSize)
            {
                clipSize = ammoCount;
                ammoCount = 0;
            }
            else
            {
                clipSize = maxClipSize;
                ammoCount -= maxClipSize;
            }
        }
    }


    // activates when buttons are held down when shooting
    public IEnumerator AutoShotRoutine()
    {
        Debug.Log($"Min Time between Shots: {gunScriptableObj.minTimeBetweenShots}");
        // while shooting, run the scriptableObj's Shoot() while checking the clip size
        while (isShooting)
        {
            if (clipSize <= 0) 
                break;
            else
            {
                Shoot();  // use the base shot
                yield return new WaitForSeconds(gunScriptableObj.minTimeBetweenShots);
            }
                
        }
    }
}
