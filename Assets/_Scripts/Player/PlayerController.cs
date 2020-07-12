using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInputs;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 20f;
    [SerializeField]
    private float jumpStrength = 30f;
    [SerializeField]
    private float gravity = -1f;
    [SerializeField]
    private float gravityFloatReduce = -1f;

    private CharacterController controller;
    private float playerHalfHeight;
    private LayerMask notPlayerLayer;

    public static GameObject PlayerBody;   
    private float currentGravity;
    private Vector3 moveVector;
    void Start()
    {
        PlayerBody = this.gameObject;
        controller = this.gameObject.GetComponent<CharacterController>();
        playerHalfHeight = controller.height / 2;
        notPlayerLayer = ~LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            if(currentGravity < 0)
                currentGravity = -5f;
            if (PlayerInput.Jump)
            {
                currentGravity = jumpStrength;
            }
            moveVector = transform.forward * PlayerInput.MoveAxis.y +
                transform.right * PlayerInput.MoveAxis.x;

            moveVector.Normalize();
            moveVector *= moveSpeed;
            moveVector.y = currentGravity;
        }
        else
        {
            
            if (currentGravity < 0 && currentGravity > gravityFloatReduce)
                currentGravity = gravityFloatReduce;

            currentGravity += gravity;
            moveVector.y = currentGravity;

        }

        controller.Move(moveVector * Time.deltaTime);
    }


    private bool IsGrounded()
    {
        Vector3 cast = this.transform.position;
        cast.y -= playerHalfHeight;
        return Physics.CheckSphere(cast, .3f, notPlayerLayer);
    }
}
