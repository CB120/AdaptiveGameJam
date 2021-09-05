using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phase2Enemies : MonoBehaviour
{
    public List<GameObject> Cubes;
    public GameObject CubeToSpawn;
    public PlayerManager PMScript;
    public GamemodeManager GMManager;
    SpawnGrid spawnGrid;

    bool hasInvoked = false;

    UIGridManager GridManager;

    // Start is called before the first frame update
    void Start()
    {
        GridManager = FindObjectOfType<UIGridManager>();
        GMManager = FindObjectOfType<GamemodeManager>();
        PMScript = FindObjectOfType<PlayerManager>();
        spawnGrid = FindObjectOfType<SpawnGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GMManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (!hasInvoked)
            {
                StartWall();
                hasInvoked = true;
            }
        }
        else
        {
            CancelInvoke("DoWalls");
            DestroyExisting();
            hasInvoked = false;
        }
    }

    void DestroyExisting()
    {
        if (Cubes.Count > 0)
        {
            for (int i = 0; i < Cubes.Count; i++)
                Cubes[i].GetComponent<Phase2Connections>().getFucked = true;
        }
        Cubes = new List<GameObject>();
    }

    void StartWall()
    {
        InvokeRepeating("DoWalls", 1.5f, 4.25f);
    }

    void DoWalls()
    {
        //reset transparency of UI
        if (GMManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            foreach (Button gridButtons in spawnGrid.Buttons)
            {
                gridButtons.GetComponent<Image>().SetTransparency(0.2f);
            }
            GridManager.DeselectAll();
        }
        CreateWall();
        CreateConnector();
        randomRemove();
    }

    void CreateWall()
    {
        if (Cubes.Count > 0)
        {
            for (int i = 0; i < Cubes.Count; i++)
                Cubes[i].GetComponent<Phase2Connections>().getFucked = true;
        }
        Cubes = new List<GameObject>();
        for (int x = -1, y = 1, z = 1, i = 0; i < 9; i++)
        {
            if (x == -1 && i < 3)
            {
                Vector3 NewPos = new Vector3(x, y, z);
                GameObject Phase2Wall = Instantiate(CubeToSpawn, NewPos, Quaternion.identity);
                Cubes.Add(Phase2Wall);
                y++;
            }
            else if (x == 0 && i >= 3 && i < 6)
            {
                Vector3 NewPos = new Vector3(x, y, z);
                GameObject Phase2Wall = Instantiate(CubeToSpawn, NewPos, Quaternion.identity);
                Cubes.Add(Phase2Wall);
                y++;
            }
            else if (x == 1 && i < 9)
            {
                Vector3 NewPos = new Vector3(x, y, z);
                GameObject Phase2Wall = Instantiate(CubeToSpawn, NewPos, Quaternion.identity);
                Cubes.Add(Phase2Wall);
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
        for (int i = 0; i < Cubes.Count; i++)
        {
            for (int y = i + 1; y < Cubes.Count; y++)
            {
                if (Vector2.Distance(Cubes[i].transform.position, Cubes[y].transform.position) >= 0.5f
                    && Vector2.Distance(Cubes[i].transform.position, Cubes[y].transform.position) <= 1f)
                {
                    AddConnection(Cubes[i], Cubes[y]);
                    AddConnection(Cubes[y], Cubes[i]);
                }
            }
        }
    }

    void AddConnection(GameObject From, GameObject To)
    {
        From.GetComponent<Phase2Connections>().ConnectedCubes.Add(To);
    }

    void randomRemove()
    {
        int amt = (int)Random.Range(0, Cubes.Count);
        int RandomStartSpot = (int)Random.Range(0, Cubes.Count);
        for (int i = 0; i < amt; i++)
        {
            GameObject nextWall = Cubes[RandomStartSpot].GetComponent<Phase2Connections>().ConnectedCubes[Random.Range(0, Cubes[RandomStartSpot].GetComponent<Phase2Connections>().ConnectedCubes.Count)];
            nextWall.tag = "Vacant";
            if (!nextWall.GetComponent<MeshRenderer>().enabled)
                amt--;
            nextWall.GetComponent<MeshRenderer>().enabled = false;
            nextWall.GetComponent<BoxCollider>().isTrigger = false;
            for (int x = 0; x < Cubes.Count; x++)
            {
                if (Cubes[x] == nextWall)
                    RandomStartSpot = x;
            }
        }
    }
}
