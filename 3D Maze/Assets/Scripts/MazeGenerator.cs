using UnityEngine;
using System.Collections;

public class MazeGenerator : ScriptableObject
{

    // height and width of maze
	public int height = 11;
	public int width = 11;

    // array stating which blocks are walls
	private bool[,] maze;

    // block prefab
    public GameObject wallPrefab;

	private static System.Random _random = new System.Random ();

    public void init(int height, int width)
    {
        wallPrefab = (GameObject)Resources.Load("Wall");

        this.height = height;
        this.width = width;

        // generates maze by stating which cubes are walls
		GenerateMaze (height, width);

        // instantiates a block gameobject for every wall
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (maze[i, j])
                {
                    GameObject wall = Instantiate(wallPrefab) as GameObject;

                    // sets a tag for the wall so it can be idetified as a group
                    //wall.tag = "wall";

                    // sets the position of the cube
                    Vector3 pos = new Vector3(i*3.5f + 7, 0, j*3.5f - 3);
                    if (wall != null)
                        wall.transform.position = pos;
                }
            }
        }
	}

    void Update()
    {
	
//		if (Input.GetButtonDown ("Fire1"))
//			test ();

	}

	private void GenerateMaze(int height, int width)
	{
        // array to stating which blocks are walls
		maze = new bool[height, width];

        // set all block initailly as walls
		for(int i = 0; i < height; i++)
			for(int j = 0; j < width; j++)
				maze[i,j] = true;

        // sets starting point of the maze
		maze[1,1] = false;
        maze[0,1] = false;

        MazeRecursion(maze, 1, 1);

        // sets ending point
        int x = width - 2;
        if (maze[height - 2, x] == false)
            maze[height - 1, x] = false;
        else
        {
            while (maze[height - 2, x--]) { }
            maze[height - 1, x] = false;
        } 
	}

	private void MazeRecursion(bool[,] maze, int r, int c)
	{

        /* North = 1
         * East = 2
         * South = 3
         * West = 4 */
		int[] directions = new int[]{1,2,3,4};
		Shuffle(directions);

        for (int i = 0; i < directions.Length; i++)
        {
            switch (directions[i])
            {
                case 1: // North
                    if (r - 2 <= 0)
                        continue;

                    if (maze[r - 2, c] != false)
                    {
                        maze[r - 2, c] = false;
                        maze[r - 1, c] = false;
                        MazeRecursion(maze, r - 2, c);
                    }

                    break;
                case 2: // East
                    if (c + 2 >= width - 1)
                        continue;

                    if (maze[r, c + 2] != false)
                    {
                        maze[r, c + 2] = false;
                        maze[r, c + 1] = false;
                        MazeRecursion(maze, r, c + 2);
                    }

                    break;
                case 3: // South
                    if (r + 2 > height - 1)
                        continue;

                    if (maze[r + 2, c] != false)
                    {
                        maze[r + 2, c] = false;
                        maze[r + 1, c] = false;
                        MazeRecursion(maze, r + 2, c);
                    }

                    break;
                case 4: // East
                    if (c - 2 <= 0)
                        continue;

                    if (maze[r, c - 2] != false)
                    {
                        maze[r, c - 2] = false;
                        maze[r, c - 1] = false;
                        MazeRecursion(maze, r, c - 2);
                    }

                    break;
            }
        }
	}

    // http://www.dotnetperls.com/fisher-yates-shuffle
	public static void Shuffle<T>(T[] array)
	{
		var random = _random;
		for (int i = array.Length; i > 1; i--)
		{
			// Pick random element to swap.
			int j = random.Next(i); // 0 <= j <= i-1
			// Swap.
			T tmp = array[j];
			array[j] = array[i - 1];
			array[i - 1] = tmp;
		}
	}
}
