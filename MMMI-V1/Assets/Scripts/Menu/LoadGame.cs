using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void LoadMazes()
    {
       SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
