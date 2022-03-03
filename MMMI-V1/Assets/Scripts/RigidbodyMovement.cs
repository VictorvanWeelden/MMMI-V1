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
    //void FixedUpdate()
    //{
    //    // Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //    var gamepad = Gamepad.current;
    //    Vector2 move; 
    //    if (gamepad == null) {
    //        Debug.Log("No gamepad detected using keyboard imputs instead");
    //        var kb = Keyboard.current;
    //        // Read keyboard values 
    //        float w = kb.wKey.ReadValue();
    //        float a = kb.aKey.ReadValue();
    //        float s = kb.sKey.ReadValue();
    //        float d = kb.dKey.ReadValue();
    //        // Combine values
    //        move = new Vector2(1 * d + -1 * a, 1 * w + -1 * s);
    //    } else {
    //        move = gamepad.dpad.ReadValue();
    //    }
    //    //Apply the movement vector to the current position, which is
    //    //multiplied by deltaTime and speed for a smooth MovePosition
    //    rigidBod.MovePosition(transform.position + new Vector3(move.x, 0, move.y) * Time.deltaTime * movementSpeed);
    //}

    void FixedUpdate() {
        // Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var gamepad = Gamepad.current;
        Vector2 moveKeyboard;
        Vector2 moveController;
        var kb = Keyboard.current;
        // Read keyboard values 
        float w = kb.wKey.ReadValue();
        float a = kb.aKey.ReadValue();
        float s = kb.sKey.ReadValue();
        float d = kb.dKey.ReadValue();
        // Combine values
        moveKeyboard = new Vector2(1 * d + -1 * a, 1 * w + -1 * s);

        // Read controller value
        moveController = gamepad.dpad.ReadValue();
       

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        if (moveKeyboard!=Vector2.zero) {
            rigidBod.MovePosition(transform.position + new Vector3(moveKeyboard.x, 0, moveKeyboard.y) * Time.deltaTime * movementSpeed);
        } else {
            rigidBod.MovePosition(transform.position + new Vector3(moveController.x, 0, moveController.y) * Time.deltaTime * movementSpeed);
        }
       
    }
}
 
   
