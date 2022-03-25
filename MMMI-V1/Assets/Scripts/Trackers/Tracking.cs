using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

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

    async void TakeScreenshot() {
        if (!Directory.Exists(Directory.GetCurrentDirectory() + "/Screenshots/")) {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Screenshots");
        }
        Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
        string fileName = Directory.GetCurrentDirectory() + "/Screenshots/" + System.DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") + "_" + PlayerPrefs.GetString("username") + GetMazeType() + "_Level" + PlayerPrefs.GetInt("level") + "_Route.png";
        ScreenCapture.CaptureScreenshot(fileName);
    }

    string GetMazeType(){
        if (PlayerPrefs.GetInt("audio") == 1 && PlayerPrefs.GetInt("haptic") == 1){
            return "COMBINED";
        }
        else if (PlayerPrefs.GetInt("audio") == 1) {
            return "AUDIO";
        }
        else if (PlayerPrefs.GetInt("haptic") == 1) {
            return "HAPTIC";
        }
        else {
            return "UNKNOWNTYPE";
        }
    }
}
