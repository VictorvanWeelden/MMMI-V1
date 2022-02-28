using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public AudioSource audioSource;
    
    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.tag == "Wall"){
             audioSource.Play();
            Debug.Log("bump");
        }
       
    }
}
