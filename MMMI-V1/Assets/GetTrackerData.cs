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
        playTimeText.text = PlayerPrefs.GetString("playTime");
        errorsText.text = PlayerPrefs.GetInt("noBumps").ToString();
    }
}
