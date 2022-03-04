using System.Collections;
//using UnityEngine;

public abstract class MazeAlgorithm
{
    protected MazeCell[,] mazeCells;
    protected int mazeRows, mazeColumns, selectmaze;
    protected MazeAlgorithm(MazeCell[,] mazeCells, int selectmaze) : base()
    {
        this.mazeCells = mazeCells;
        mazeRows = mazeCells.GetLength(0);
        mazeColumns = mazeCells.GetLength(1);
        this.selectmaze = selectmaze;
    }
    public abstract void CreateMaze();

}
