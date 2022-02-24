using System.Collections;
using UnityEngine;

public abstract class MazeAlgorithm
{
    protected MazeCell[,] mazeCells;
    protected int mazeRows, mazeColumns;
    protected MazeAlgorithm(MAzeCell[,] mazeCells) : base()
    {
        this.mazeCells = mazeCells;
        mazeRows = mazeCells.GetLength(0);
        mazeColumns = mazeCells.GetLength(1);
    }
    public abstract void CreateMaze();

}
