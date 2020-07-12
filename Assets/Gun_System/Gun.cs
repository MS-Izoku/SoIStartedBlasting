using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun (basic)", menuName = "Guns/Gun(basic)")]
public class Gun : ScriptableObject
{
    public string gunName = "Name of the Gun in-game!";
    public string description = "Gun Description, use this later!";
    public GameObject bulletFeedbackObj;
    public GameObject shootingFeedbackObj;
    public GameObject bullet;
    public float minTimeBetweenShots = 0.25f;
    [Range(0, 500)] public int ammoCount = 30;
    public int clipSize = 30;
    public bool isAutomatic = false;
    private int maxClipSize;

    public bool useRecoil = false;
    public float recoilAmount = 1f;

    private void Awake()
    {
        maxClipSize = clipSize;
    }
}
