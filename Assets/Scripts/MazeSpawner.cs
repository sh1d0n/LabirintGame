using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject CellPrefab;
    public GameObject FinishCellPrefab;
    private int width = 23;
    private int height = 15;

    void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze();

        for(int x = 0; x < maze.GetLength(0); x++)
        {
            for(int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector2(x,y), Quaternion.identity).GetComponent<Cell>();

                c.wallLeft.SetActive(maze[x, y].wallLeft);
                c.wallBottom.SetActive(maze[x, y].wallBottom);

                if((x == 0 || x == width - 1) && !c.wallLeft.activeSelf)
                {
                    Cell c1 = Instantiate(FinishCellPrefab, new Vector2(x,y), Quaternion.identity).GetComponent<Cell>();
                    c1.wallLeft.SetActive(true);
                    c1.wallBottom.SetActive(false);
                }
                else if((y == 0 || y == height - 1) && !c.wallBottom.activeSelf)
                {
                    Cell c1 = Instantiate(FinishCellPrefab, new Vector2(x,y), Quaternion.identity).GetComponent<Cell>();
                    c1.wallLeft.SetActive(false);
                    c1.wallBottom.SetActive(true);
                }
            }
        }
    }


}
