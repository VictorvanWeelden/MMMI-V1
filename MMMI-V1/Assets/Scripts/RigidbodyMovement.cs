using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyMovement : MonoBehaviour
{
    Rigidbody rigidBod;
    public float movementSpeed = 10f;
    Vector3 walkingDirecion;
    Vector2 moveKeyboard;
    Vector2 moveController;
    float w, a , s, d, output;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var gamepad = Gamepad.current;

        var kb = Keyboard.current;
        // Read keyboard values 
        w = kb.wKey.ReadValue();
        a = kb.aKey.ReadValue();
        s = kb.sKey.ReadValue();
        d = kb.dKey.ReadValue();
        // Combine values
        moveKeyboard = new Vector2(1 * d + -1 * a, 1 * w + -1 * s);

        // Read controller value
        if (gamepad != null) {
            moveController = gamepad.dpad.ReadValue();
        }
     
      
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
            if (gamepad != null && (PlayerPrefs.GetInt("haptic") == 1) ) {
                gamepad.SetMotorSpeeds(motorspeed, motorspeed);
            }

            var audioFrequency = RescaleAudio(hit.distance, 8);
            audioSource = GetComponent<AudioSource>();
            audioSource.pitch = audioFrequency;
            if (PlayerPrefs.GetInt("audio") == 1) audioSource.Play();
        }
        

    }   
    // Rescales the distance from the player to the wall to fit the rumbling of the controller
    private float Rescale(float input, float startdistance) {
        output = 0;
        if (input >= startdistance) return output;
        output = (float)((input-startdistance) *-1/startdistance);
        return output;
    }
// Rescale for the audio frequency
    private float RescaleAudio(float distance, float startingPitch){
        
        float audioFreq = startingPitch - 2*distance; //we can put 2 * distance if you think the sound is appearing too soon, I was not sure what I like more
        return audioFreq;
        
    }

}