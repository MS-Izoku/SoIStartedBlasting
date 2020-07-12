using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInputs;

public class PlayerRotation : MonoBehaviour
{
    private float rotationAmt;

    [SerializeField]
    private float mouseSensitivity = 200;
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotationAmt = PlayerInput.LookAxisX * mouseSensitivity * Time.deltaTime;

        Vector3 rotatePlayer = this.gameObject.transform.rotation.eulerAngles;

        rotatePlayer.y += rotationAmt;

        this.gameObject.transform.rotation = Quaternion.Euler(rotatePlayer);
    }
}
