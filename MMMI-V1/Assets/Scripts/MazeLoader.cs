using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeLoader : MonoBehaviour
{

    public int mazeRows, mazeColumns;
    public GameObject wall;
    public GameObject startfloor;
    public GameObject Finishfloor;
    public int selectmaze;
    public float size = 2f; 

    private MazeCell[,] mazeCells;
    // Start is called before the first frame update
    public void Start()
    {
        selectmaze = PlayerPrefs.GetInt("level");
        InitializeMaze();

        MazeAlgorithm ma = new HuntAndKillAlgorithm(mazeCells, selectmaze);
        ma.CreateMaze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeMaze()
    {
        mazeCells = new MazeCell[mazeRows, mazeColumns];

        for(int r = 0; r <mazeRows; r++)
        {
            for (int c = 0; c < mazeColumns; c++)
        {
                mazeCells[r, c] = new MazeCell();

                if (r == 0 && c == 0)
                {
                    mazeCells[r, c].floor = Instantiate(startfloor, new Vector3((r * size), -(size / 2f), (c * size)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].floor.name = "StartFloor" + r + "," + c;
                    mazeCells[r, c].floor.transform.Rotate(Vector3.right * 90f);
                }
                else if(r == mazeRows -1 && c == mazeColumns -1)
                {
                    mazeCells[r, c].floor = Instantiate(Finishfloor, new Vector3((r * size), -(size / 2f), (c * size)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].floor.name = "FinishFloor" + r + "," + c;
                    mazeCells[r, c].floor.transform.Rotate(Vector3.right * 90f);
                }
                else 
                {
                    mazeCells[r, c].floor = Instantiate(wall, new Vector3((r * size), -(size / 2f), (c * size)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].floor.name = "Floor" + r + "," + c;
                    mazeCells[r, c].floor.transform.Rotate(Vector3.right * 90f);
                }

                if(c == 0)
                {
                    mazeCells[r, c].westWall = Instantiate(wall, new Vector3((r * size), 0, (c * size) - (size / 2f)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].westWall.name = "West wall " + r + "," + c;
                }

                mazeCells[r,c].eastWall = Instantiate(wall, new Vector3((r *size), 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
                mazeCells[r, c].eastWall.name = "East wall " + r + "," + c;

                if(r == 0)
                {
                    mazeCells[r, c].northWall = Instantiate(wall, new Vector3((r * size) - (size / 2f), 0, (c * size)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].northWall.name = "North wall " + r + "," + c;
                    mazeCells[r, c].northWall.transform.Rotate(Vector3.up * 90f);
                }

               mazeCells[r, c].southWall = Instantiate(wall, new Vector3((r * size) + (size / 2f), 0, (c * size)), Quaternion.identity) as GameObject;
               mazeCells[r, c].southWall.name = "South wall " + r + "," + c;
               mazeCells[r, c].southWall.transform.Rotate(Vector3.up * 90f);
            }
        }
    }
}
