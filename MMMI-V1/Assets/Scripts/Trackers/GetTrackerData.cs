using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTrackerData : MonoBehaviour
{
    public Text playTimeText;
    public Text errorsText;
    public Text playerName;
    // Start is called before the first frame update
    void Start()
    {
        playTimeText.text = "Time played: " + PlayerPrefs.GetString("playTime");
        errorsText.text = "Wall bumps: " + PlayerPrefs.GetInt("noBumps").ToString();
        playerName.text = "Player: " + PlayerPrefs.GetString("username");
        TakeScreenshot();
    }

    void TakeScreenshot() {
        string fileName = Application.dataPath + "/Screenshots/" + System.DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") + "_" + PlayerPrefs.GetString("username") + "_" + GetMazeType() + "_Level" + PlayerPrefs.GetInt("level") + "_TimeErrs_";
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
