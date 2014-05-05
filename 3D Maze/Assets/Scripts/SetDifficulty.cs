using UnityEngine;
using System.Collections;

public class SetDifficulty : MonoBehaviour {

    public bool isEasy = false;
    public bool isMedium = false;
    public bool isHard = false;

    public GameObject easy;
    public GameObject medium;
    public GameObject hard;

    GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        
        MazeGenerator mazeGenerator = ScriptableObject.CreateInstance("MazeGenerator") as MazeGenerator;

        // destory all walls
        gameObjects = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject gameObject in gameObjects)
            Destroy(gameObject);

        if (isEasy)
        {
            mazeGenerator.init(15, 15);
            renderer.material.color = Color.cyan;
            medium.renderer.material.color = Color.white;
            hard.renderer.material.color = Color.white;
        }
        else if (isMedium)
        {
            mazeGenerator.init(31, 31);
            renderer.material.color = Color.cyan;
            easy.renderer.material.color = Color.white;
            hard.renderer.material.color = Color.white;
        }
        else if (isHard)
        {
            mazeGenerator.init(61, 61);
            renderer.material.color = Color.cyan;
            easy.renderer.material.color = Color.white;
            medium.renderer.material.color = Color.white;
        }
    }
}
