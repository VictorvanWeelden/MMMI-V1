using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracking : MonoBehaviour
{
    protected float completionTime = 0;
    protected int noWallBumps = 0;
    // Start is called before the first frame update
    void Start()
    {
        completionTime = 0;
        noWallBumps = 0;
    }

    void Update() {
        completionTime += Time.deltaTime();
    }

    public String ReturnCompletionTime() {
        int minutes = Mathf.FloorToInt(Timer / 60F);
	    int seconds = Mathf.FloorToInt(Timer % 60F);
	    int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        return minutes + ":" + seconds + ":" + milliseconds;
    }
}
