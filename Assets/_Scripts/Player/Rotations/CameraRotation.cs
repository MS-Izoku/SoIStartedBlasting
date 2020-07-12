using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInputs;

public class CameraRotation : MonoBehaviour
{

    private float rotationAmt = 0;
    [SerializeField]
    private float lookSensetivity = 200;
    // Update is called once per frame
    void Update()
    {
        rotationAmt += PlayerInput.LookAxisY * lookSensetivity * Time.deltaTime;
        rotationAmt = Mathf.Clamp(rotationAmt, -80, 65);
        this.transform.localRotation = Quaternion.Euler(-rotationAmt, 0, 0);
    }
}
