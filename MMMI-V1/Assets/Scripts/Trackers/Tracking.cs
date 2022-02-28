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
        completionTime += Time.deltaTime;
    }

    // Call this when the player has completed the level
    public string ReturnCompletionTime() {
        int minutes = Mathf.FloorToInt(completionTime / 60F);
	    int seconds = Mathf.FloorToInt(completionTime % 60F);
	    int milliseconds = Mathf.FloorToInt((completionTime * 100F) % 100F);
        return minutes + ":" + seconds + ":" + milliseconds;
    }
}
