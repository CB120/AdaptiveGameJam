using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> EnemyWall;
    public GameObject Wall;
    public GameObject ParentWall;
    void Start()
    {
        InitWalls();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            InitWalls();
            CreateConnector();
            CreateRandomWall();
        }
    }

    void InitWalls()
    {
        if (EnemyWall.Count > 0)
        {
            for (int i = 0; i < EnemyWall.Count; i++)
                Destroy(EnemyWall[i]);
        }
        EnemyWall = new List<GameObject>();


        for (int x = -1, y = 1, z = 1, i = 0; i < 9; i++)
        {
            if (x == -1 && i < 3)
            {
                Vector3 NewPos = new Vector3(x, y, z);
                GameObject NewWall = Instantiate(Wall, NewPos, Quaternion.identity);
                NewWall.transform.parent = ParentWall.transform;
                NewWall.name = "Wall " + i;
                EnemyWall.Add(NewWall);
                y++;
            }
            else if (x == 0 && i >= 3 && i < 6)
            {
                Vector3 NewPos = new Vector3(x, y, z);
                GameObject NewWall = Instantiate(Wall, NewPos, Quaternion.identity);
                NewWall.transform.parent = ParentWall.transform;
                NewWall.name = "Wall " + i;
                EnemyWall.Add(NewWall);
                y++;
            }
            else if (x == 1 && i < 9)
            {
                Vector3 NewPos = new Vector3(x, y, z);
                GameObject NewWall = Instantiate(Wall, NewPos, Quaternion.identity);
                NewWall.transform.parent = ParentWall.transform;
                NewWall.name = "Wall " + i;
                EnemyWall.Add(NewWall);
                y++;
            }

            if (y > 3)
            {
                y = 1;
                x++;
            }
        }
    }

    void CreateConnector()
    {
        for (int i = 0; i < EnemyWall.Count; i++)
        {
            for (int y = i + 1; y < EnemyWall.Count; y++)
            {
                if (Vector2.Distance(EnemyWall[i].transform.position, EnemyWall[y].transform.position) >= 0.5f
                    && Vector2.Distance(EnemyWall[i].transform.position, EnemyWall[y].transform.position) <= 1f)
                {
                    AddConnection(EnemyWall[i], EnemyWall[y]);
                    AddConnection(EnemyWall[y], EnemyWall[i]);
                }
            }
        }
    }

    void AddConnection(GameObject From, GameObject To)
    {
        From.GetComponent<EnemyConnector>().ConnectedCubes.Add(To);
    }

    void CreateRandomWall()
    {
        int RandomAmount = (int)Random.Range(1, EnemyWall.Count);
        int RandomStartSpot = (int)Random.Range(0, EnemyWall.Count);
        for (int i = 0; i < RandomAmount; i++)
        {
            //EnemyWall[RandomStartSpot].GetComponent<MeshRenderer>().enabled = false;
            GameObject nextWall = EnemyWall[RandomStartSpot].GetComponent<EnemyConnector>().ConnectedCubes[Random.Range(0, EnemyWall[RandomStartSpot].GetComponent<EnemyConnector>().ConnectedCubes.Count)];

            nextWall.GetComponent<MeshRenderer>().enabled = false;
            nextWall.GetComponent<BoxCollider>().isTrigger = true;
            for (int x = 0; x < EnemyWall.Count; x++)
            {
                if (EnemyWall[x] == nextWall)
                    RandomStartSpot = x;
            }
        }
    }
}
