using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour 
    {

    [SerializeField] Toggle mazeToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mazeToggle.isOn) {
            gameObject.transform.position = new Vector3(12, 40, 12);
        } else {
            gameObject.transform.position = new Vector3(12, -10, 12);
        }
    }
}
