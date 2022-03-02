using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTrackerData : MonoBehaviour
{
    public Text playTimeText;
    public Text errorsText;
    // Start is called before the first frame update
    void Start()
    {
        playTimeText.text = "Time played: " + PlayerPrefs.GetString("playTime");
        errorsText.text = "Wall bumps: " + PlayerPrefs.GetInt("noBumps").ToString();
    }
}
