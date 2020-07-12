using UnityEngine;
using TMPro;

public class AmmoTracker : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI displayObj;

    public string display { 
        get {
            if (ShootingController.currentGun != null)
            {
                GunObject gunObj = ShootingController.currentGun;
                return $"( {gunObj.clipSize} / {gunObj.ammoCount} )";
            }
            else return "( 0 / 0 )";
        }
    }

    private void Start()
    {
        displayObj = GetComponent<TextMeshProUGUI>();
        displayObj.text = display;
    }

    private void Update()
    {
        displayObj.text = display;
    }
}
