using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyMovement : MonoBehaviour
{
    Rigidbody rigidBod;
    public float movementSpeed = 10f;
    Vector3 walkingDirecion;
    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody>();
    }

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
            walkingDirecion = new Vector3(moveKeyboard.x, 0,moveKeyboard.y);
        } else {
            rigidBod.MovePosition(transform.position + new Vector3(moveController.x, 0, moveController.y) * Time.deltaTime * movementSpeed);
            walkingDirecion = new Vector3(moveController.x, 0,moveController.y);
        }
    }
    void Update() {
        // Create ray to messure distance to the wall the player is walking towards
        RaycastHit hit;
        Ray directionRay = new Ray(rigidBod.position, walkingDirecion);
        if(Physics.Raycast(directionRay,out hit)) {
            var motorspeed = Rescale(hit.distance,3);
            var gamepad = Gamepad.current;
            if (gamepad != null) {
                gamepad.SetMotorSpeeds(motorspeed, motorspeed);
            }
        }
    }   
    // Rescales the distance from the player to the wall to fit the rumbling of the controller
    private float Rescale(float input, float startdistance) {
        float output = 0;
        if (input >= startdistance) return output;
        output = (float)((input-startdistance) *-1/startdistance);
        return output;
    }

}