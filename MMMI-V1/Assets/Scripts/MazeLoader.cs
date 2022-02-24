using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int mazeRows, mazeColumns;
    public GameObject wall;
    public float size = 2f;

    private MazeCell[,] mazeCells;
    // Start is called before the first frame update
    void Start()
    {
        InitializeMaze();

        MazeAlgorithm ma = new HuntAndKillAlg(mazeCells);
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

                mazeCells[r, c].floor = Instantiate(wall, new Vector3(r * size, -(size / 2f), c * size), Quaternion.identity) as GameObject;
                mazeCells[r, c].floor.name = "Floor" + r + "," + c;
                mazeCells[r, c].floor.transform.Rotate(Vector3.right, 90f);

                if(c == 0)
                {
                    mazeCells[r, c].westWall = Instantiate(wall, new Vector3(r * size, 0, (c * size) - (size / 2f)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].westWall.name = "West wall " + r + "," + c;
                }

                mazeCells[r,c].eastWall = Instantiate(wall, new Vector3(r *size, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
                mazeCells[r, c].eastWall.name = "East wall " + r + "," + c;

        if(r == 0)
        {
                    mazeCells[r, c].northWall = Instantiate(wall, new Vector3((r * size) - (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
                    mazeCells[r, c].northWall.name = "North wall " + r + "," + c;
                    mazeCells[r, c].floor.transform.Rotate(Vector3.up * 90f);
                }
                mazeCells[r, c].southWall = Instantiate(wall, new Vector3((r * size) +(size / 2f), 0, c * size), Quaternion.identity) as GameObject;
                mazeCells[r, c].southWall.name = "South wall " + r + "," + c;
                mazeCells[r, c].floor.transform.Rotate(Vector3.up * 90f);
            }
        }
    }
}
