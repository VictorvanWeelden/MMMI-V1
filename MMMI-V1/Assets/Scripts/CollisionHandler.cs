using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CollisionHandler : MonoBehaviour
{
    public AudioSource audioSource;
    
    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.tag == "Wall"){
             audioSource.Play();
            Debug.Log("bump");
            var gamepad = Gamepad.current;
            StartCoroutine(Rumble());
                     
        }
       
    }

    IEnumerator Rumble() {
        // TODO Make rumbling linear depending on distance from the walls
        var gamepad = Gamepad.current;
        if (gamepad != null) {
            gamepad.SetMotorSpeeds(0.5f, 0.5f);
            yield return new WaitForSeconds(0.2f);
            gamepad.SetMotorSpeeds(0, 0);
        }
    }
}
