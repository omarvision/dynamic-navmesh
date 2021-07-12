using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //for navmesh

public class LevelGen : MonoBehaviour
{
    public NavMeshSurface NavSurface = null;
    public GameObject Player = null;
    public GameObject prefabWall = null;
    public GameObject prefabObstacle = null;
    public float RangeX = 13.0f;
    public float RangeZ = 13.0f;
    public int Chance = 25;
    public bool MakeWalls = true;
    private bool Placed = false;

    private void Start()
    {
        if (MakeWalls == true)
        {
            Generate();
        }

        // script command to build navmesh (NavMeshSurface component)
        NavSurface.BuildNavMesh();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) == true)
        {
            Debug.Log("right mouse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) == true)
            {
                GameObject obj = Instantiate(prefabObstacle);
                obj.transform.position = hit.point;
            }
        }
    }
    private void Generate()
    {
        for (float z = -RangeZ; z < RangeZ; z += 3)
        {
            for (float x = -RangeX; x < RangeX; x += 3)
            {
                if (Random.Range(0, 100) < Chance)
                {
                    GameObject wall = Instantiate(prefabWall, this.transform);
                    wall.transform.position = new Vector3(x, 1.0f, z);
                }
                else if (Placed == false)
                {
                    Placed = true;
                    Player.transform.position = new Vector3(x, 1.0f, z);
                }
            }
        }
    }
}
