using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUserName : MonoBehaviour
{
    public void GetInput() {
        Toggle level1 = GameObject.Find("Level1Toggle").GetComponent<Toggle>();
        Toggle level2 = GameObject.Find("Level2Toggle").GetComponent<Toggle>();
        Toggle audio = GameObject.Find("AudioToggle").GetComponent<Toggle>();
        Toggle haptic = GameObject.Find("HapticToggle").GetComponent<Toggle>();
        ToggleGroup inputLevel = GameObject.Find("Level Group").GetComponent<ToggleGroup>();
        InputField inputName = GameObject.Find("User ID").GetComponent<InputField>();

        PlayerPrefs.SetString("username", inputName.text);
        
        if(level1.isOn) {
            PlayerPrefs.SetInt("level", 1);
        } else if (level2.isOn) {
            PlayerPrefs.SetInt("level", 2);
        } else {
            PlayerPrefs.SetInt("level", 3);
        }
        int audioInt = audio.isOn ? 1 : 0;
        int hapticInt = haptic.isOn ? 1 : 0;
        PlayerPrefs.SetInt("audio", audioInt);
        PlayerPrefs.SetInt("haptic", hapticInt);

       // Debug.Log(PlayerPrefs.GetInt("level"));
        Debug.Log("Audio" + PlayerPrefs.GetInt("audio"));
        Debug.Log("Haptic" + PlayerPrefs.GetInt("haptic"));
        //Debug.Log(inputName.text);
    }
}
