using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerInputs
{
    public class PlayerInput : MonoBehaviour
    {
        public static Vector2 MoveAxis
        {
            get { return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); }
        }

        public static float LookAxisX
        {
            get { return Input.GetAxis("Mouse X"); }
        }

        public static float LookAxisY
        {
            get { return Input.GetAxis("Mouse Y"); }
        }

        public static bool Jump
        {
            get { return Input.GetButtonDown("Jump"); }
        }

        public static bool FireGun
        {
            get { return Input.GetButtonDown("Fire1"); }
        }
    }
}

