using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntAndKillAlgorithm : MazeAlgorithm
{
    private int currentRow = 0;
    private int currentColumn = 0;
    private int direction;
    private int availableRoutes, visitedCells, selectmazex;

    private bool courseComplete = false;
    public bool autoGenerateMaze = false;
    private bool wallDestroyed;

    public int currentPos = 0;
    public const string key1 = "2324223132311413144";
    public const string key2 = "32422231131132324242331";
    public const string key3 = "3242223113333234442";
    public string key;
    public string currentNum;
    
    public HuntAndKillAlgorithm(MazeCell[,] mazeCells, int selectmaze) : base(mazeCells, selectmaze) { selectmazex = selectmaze; }

    public override void CreateMaze()
    {
        selectMaze();
        HuntAndKill();
    }

    public void selectMaze()
    {
        if (selectmazex == 1)
        {
            key = key1;
        }
        else if (selectmazex == 2)
        {
            key = key2;
        }
        else
        {
            key = key3;
        }
    }

    private void HuntAndKill()
    {
        mazeCells[currentRow, currentColumn].visited = true;

        while (!courseComplete)
        {
            Kill();
            Hunt();
        }
    }

    public int GetNextNumber()
    {
        currentNum = key.Substring(currentPos++ % key.Length, 1);
        return int.Parse(currentNum);
    }

    private void Kill()
    {
        while(RouteStillAvailable(currentRow, currentColumn))
        {
            if (autoGenerateMaze)
            {
                direction = Random.Range(1, 5);
            }
            else
            {
                direction = GetNextNumber();
            }  
            if (direction == 1 && CellIsAvailable(currentRow -1, currentColumn))
            { //North
                DestroyWallIfItExists(mazeCells[currentRow, currentColumn].northWall);
                DestroyWallIfItExists(mazeCells[currentRow - 1, currentColumn].southWall);
                currentRow--;
            }
            else if(direction == 2 && CellIsAvailable(currentRow +1, currentColumn))
            { // South
                DestroyWallIfItExists(mazeCells[currentRow, currentColumn].southWall);
                DestroyWallIfItExists(mazeCells[currentRow + 1, currentColumn].northWall);
                currentRow++;
            }
            else if(direction == 3 && CellIsAvailable(currentRow, currentColumn +1))
            { //east
                DestroyWallIfItExists(mazeCells[currentRow, currentColumn].eastWall);
                DestroyWallIfItExists(mazeCells[currentRow, currentColumn + 1].westWall);
                currentColumn++;
            }
            else if(direction == 4 && CellIsAvailable(currentRow, currentColumn - 1))
            {
                DestroyWallIfItExists(mazeCells[currentRow, currentColumn].westWall);
                DestroyWallIfItExists(mazeCells[currentRow, currentColumn - 1].eastWall);
                currentColumn--;
            }
            mazeCells[currentRow, currentColumn].visited = true;
        }
    }

    private void Hunt()
    {
        courseComplete = true; 
        for (int r = 0; r < mazeRows; r++)
        {
            for(int c = 0; c < mazeColumns; c++)
            {
                if(!mazeCells[r,c].visited && CellHasAnAdjacentVisitedCell(r,c))
                {
                    courseComplete = false;
                    currentRow = r;
                    currentColumn = c;
                    DestroyAdjacentWall(currentRow, currentColumn);
                    mazeCells[currentRow, currentColumn].visited = true;
                    return;
                }
            }
        }
    }

    private bool RouteStillAvailable(int row, int column)
    {
        availableRoutes = 0;
        if (row > 0)
        {
            if(!mazeCells[row - 1, column].visited)
            {
                availableRoutes++;
            }
        }
        if (row < (mazeRows - 1))
        {
            if (!mazeCells[row + 1, column].visited)
            {
                availableRoutes++;
            }
        }
        if (column > 0)
        {
            if (!mazeCells[row, column - 1].visited)
            {
                availableRoutes++;
            }
        }
        if (column < (mazeColumns - 1))
        {
            if (!mazeCells[row, column + 1].visited)
            {
                availableRoutes++;
            }
        }
        return availableRoutes > 0;
    }

    private bool CellIsAvailable(int row, int column)
    {
        if (row >= 0 && row < mazeRows && column >= 0 && column < mazeColumns)
        {
            if (!mazeCells[row, column].visited)
            { return true; }
        }
        return false;
    }

    private void DestroyWallIfItExists(GameObject wall)
    {
        if (wall != null)
        {
            GameObject.Destroy(wall);
        }
    }

    private bool CellHasAnAdjacentVisitedCell( int row, int column)
    {
        visitedCells = 0;
        if(row > 0 && mazeCells[row -1, column].visited)
        {
            visitedCells++;
        }

        if(row < (mazeRows-2) && mazeCells[row + 1, column].visited)
        {
            visitedCells++;
        }
        if(column > 0 && mazeCells[row, column -1].visited)
        {
            visitedCells++;
        }
        if(column < (mazeColumns -2) && mazeCells[row, column +1].visited)
        {
            visitedCells++;
        }
        return visitedCells > 0;
    }

    private void DestroyAdjacentWall(int row, int column)
    {
        wallDestroyed = false;
        while(!wallDestroyed)
        {
            if (autoGenerateMaze)
            {
                direction = Random.Range(1, 5);
            }
            else
            {
                direction = GetNextNumber();
            }
            if (direction == 1 && row > 0 && mazeCells[row -1, column].visited)
            {
                DestroyWallIfItExists(mazeCells[row, column].northWall);
                DestroyWallIfItExists(mazeCells[row -1, column].southWall);
                wallDestroyed = true;
            }
            else if(direction == 2 && row < (mazeRows -2) && mazeCells[row + 1, column].visited)
            {
                DestroyWallIfItExists(mazeCells[row, column].southWall);
                DestroyWallIfItExists(mazeCells[row + 1, column].northWall);
                wallDestroyed = true;
            }
            else if (direction == 3 && column > 0 && mazeCells[row, column -1].visited)
            {
                DestroyWallIfItExists(mazeCells[row, column].westWall);
                DestroyWallIfItExists(mazeCells[row, column -1].eastWall);
                wallDestroyed = true;
            }
            else if (direction == 4 && column < (mazeColumns - 2) && mazeCells[row, column +1].visited)
            {
                DestroyWallIfItExists(mazeCells[row, column].eastWall);
                DestroyWallIfItExists(mazeCells[row, column+1].westWall);
                wallDestroyed = true;
            }
        }
    }
}
