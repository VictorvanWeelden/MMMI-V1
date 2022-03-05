using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionHandler : MonoBehaviour
{
   // public AudioSource audioSource;

    void Start(){
        PlayerPrefs.SetInt("noBumps", 0);
    }
    
    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.tag == "Wall"){
           //  audioSource.Play();
            Debug.Log("bump");
            GetSetErrors();    
        }
       
    }
    void GetSetErrors() {
        int currErrs = PlayerPrefs.GetInt("noBumps");
        PlayerPrefs.SetInt("noBumps", currErrs + 1);
    }
}
