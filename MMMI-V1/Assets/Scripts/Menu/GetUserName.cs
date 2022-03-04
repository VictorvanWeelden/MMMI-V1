using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUserName : MonoBehaviour
{
    public void GetInput() {
        InputField input = GameObject.Find("User ID").GetComponent<InputField>();
        PlayerPrefs.SetString("username", input.text);
        Debug.Log(input.text);
    }
}
