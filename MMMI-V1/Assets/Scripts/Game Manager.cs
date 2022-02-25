using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates states;

    void Awake()
    {
        Instance = this;
    }

    public enum GameStates
    {
        Start,
        MakeMaze, 
        WalkMaze,
        FinishMaze
    }

    // Add logic to change game states

    public void ChangeGameStates(GameStates newstate)
    {
        states = newstate;
    }
}
