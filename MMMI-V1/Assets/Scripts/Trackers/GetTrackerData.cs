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
        string fileName = @"Assets\Screenshots\" + PlayerPrefs.GetString("username") + "_MAZETYPE_TimeErrs_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss");
        ScreenCapture.CaptureScreenshot(fileName);
    }
}
