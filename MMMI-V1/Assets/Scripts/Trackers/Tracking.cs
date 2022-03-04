using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tracking : MonoBehaviour
{
    protected float completionTime = 0;
    protected int noWallBumps = 0;
    GameObject playerObject = null;
    GameObject finishObject = null;

    // Start is called before the first frame update
    void Start()
    {
        completionTime = 0;
        noWallBumps = 0;
        //playerObject = GameObject.Find("Capsule");
        //finishObject = GameObject.Find("FinishFloor");
    }

    void Update() {
        completionTime += Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish"){
            
            Debug.Log("End tile found");
            string completionTime = ReturnCompletionTime();
            Debug.Log(completionTime);
            PlayerPrefs.SetString("playTime", completionTime);
            TakeScreenshot();
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    // Call this when the player has completed the level
    public string ReturnCompletionTime() {
        int minutes = Mathf.FloorToInt(completionTime / 60F);
	    int seconds = Mathf.FloorToInt(completionTime % 60F);
	    int milliseconds = Mathf.FloorToInt((completionTime * 100F) % 100F);
        return minutes + ":" + seconds + ":" + milliseconds;
    }

    void TakeScreenshot() {
        Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
        string fileName = @"Assets\Screenshots\ " + System.DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss");
        ScreenCapture.CaptureScreenshot(fileName);
    }
}
