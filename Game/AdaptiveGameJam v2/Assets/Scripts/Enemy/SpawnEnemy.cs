using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> EnemyWall;
    public GameObject Wall;
    public GameObject ParentWall;
    public GameObject WallOutline;
    public GameObject AlternateCamPos;
    public PlayerManager PMScript;

    private float camMoveSpeed = 5.0f;

    public bool alternateGameMode = false;
    [SerializeField]
    List<GameObject> CameraLocations;
    SpawnGrid spawnGrid;

    public Camera MainCam;

    Phase2Enemies NewEnemies;
    void Start()
    {
        spawnGrid = FindObjectOfType<SpawnGrid>();
        PMScript = FindObjectOfType<PlayerManager>();
        NewEnemies = FindObjectOfType<Phase2Enemies>();

        if (!PMScript.gameOver)
            InvokeRepeating("DoWalls", 1.0f, 3.0f);
    }

    bool phaseChange = false;

    private void Update()
    {
        if (PMScript.gameOver)
        {
            CancelInvoke("DoWalls");
            CancelInvoke("CamSwapper");
            CancelInvoke("InitWalls");
            MainCam.transform.position = new Vector3(0, 3, -10);
            MainCam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (alternateGameMode && !PMScript.gameOver)
        {
            CancelInvoke("DoWalls");
            InvokeRepeating("CamSwapper", 0, 6.0f);
            if (!phaseChange)
            {
                phaseChange = true;
                Phase2Walls();
                for (int i = 0; i < spawnGrid.Cubes.Length; i++)
                {
                    if (spawnGrid.Cubes[i])
                    {
                        if (spawnGrid.Cubes[i].activeInHierarchy)
                            Destroy(spawnGrid.Cubes[i]);
                    }
                }
            }
        }
        else if(!alternateGameMode && !PMScript.gameOver)
        {
            if (phaseChange)
            {
                CancelInvoke("CamSwapper");
                CancelInvoke("InitWalls");
                InvokeRepeating("DoWalls", 1.0f, 3.0f);
                MainCam.transform.position = new Vector3(0, 3, -10);
                MainCam.transform.rotation = Quaternion.Euler(0, 0, 0);
                phaseChange = false;
            }
        }
    }

    void DoWalls()
    {
        InitWalls();
        CreateConnector();
        CreateRandomWall();
    }

    void Phase2Walls()
    {
        InvokeRepeating("InitWalls", 1.0f, 4.5f);
    }

    void CamSwapper()
    {
        if (CameraLocations[0])
        {
            Vector3 lerpCam = CameraLocations[0].transform.position;

            MainCam.transform.position = Vector3.Lerp(MainCam.transform.position, lerpCam, camMoveSpeed * Time.deltaTime);
            MainCam.transform.rotation = Quaternion.Euler(25, 180, 0);
        }
    }

    void InitWalls()
    {
        EnemyWall = new List<GameObject>();
        CameraLocations = new List<GameObject>();

        for (int x = -1, y = 1, z = 1, i = 0; i < 9; i++)
        {
            if (x == -1 && i < 3)
            {
                Vector3 NewPos = new Vector3(x, y, z + 40);
                GameObject NewWall = Instantiate(Wall, NewPos, Quaternion.identity);
                NewWall.transform.parent = ParentWall.transform;
                NewWall.name = "Wall " + i;
                EnemyWall.Add(NewWall);
                y++;
            }
            else if (x == 0 && i >= 3 && i < 6)
            {
                Vector3 NewPos = new Vector3(x, y, z + 40);
                GameObject NewWall = Instantiate(Wall, NewPos, Quaternion.identity);
                NewWall.transform.parent = ParentWall.transform;
                NewWall.name = "Wall " + i;
                EnemyWall.Add(NewWall);
                y++;
            }
            else if (x == 1 && i < 9)
            {
                Vector3 NewPos = new Vector3(x, y, z + 40);
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
        Instantiate(WallOutline, new Vector3(0, 0, 41), Quaternion.identity);
        GameObject CamPos = Instantiate(AlternateCamPos, new Vector3(0, 10, 50), Quaternion.identity);
        CameraLocations.Add(CamPos);
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
        int AmountToPass = RandomAmount;
        int RandomStartSpot = (int)Random.Range(0, EnemyWall.Count);
        for (int i = 0; i < RandomAmount; i++)
        {
            GameObject nextWall = EnemyWall[RandomStartSpot].GetComponent<EnemyConnector>().ConnectedCubes[Random.Range(0, EnemyWall[RandomStartSpot].GetComponent<EnemyConnector>().ConnectedCubes.Count)];
            nextWall.tag = "Vacant";
            if (!nextWall.GetComponent<MeshRenderer>().enabled)
                AmountToPass--;
            nextWall.GetComponent<MeshRenderer>().enabled = false;
            nextWall.GetComponent<BoxCollider>().isTrigger = true;
            nextWall.GetComponent<EnemyConnector>().AmtToPass = AmountToPass;
            for (int x = 0; x < EnemyWall.Count; x++)
            {
                if (EnemyWall[x] == nextWall)
                    RandomStartSpot = x;
            }
        }
    }


}
