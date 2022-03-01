using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyMovement : MonoBehaviour
{
    Rigidbody rigidBod;
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            var gamepad = Gamepad.current;
            if (gamepad == null)
                return; // No gamepad connected.

            if (gamepad.rightTrigger.wasPressedThisFrame) {
            // 'Use' code here
        }

       // Vector2 move = gamepad.leftStick.ReadValue();
        Vector2 move = gamepad.dpad.ReadValue();
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rigidBod.MovePosition(transform.position + new Vector3(move.x,0,move.y) * Time.deltaTime * movementSpeed);
    }
}
 
   
