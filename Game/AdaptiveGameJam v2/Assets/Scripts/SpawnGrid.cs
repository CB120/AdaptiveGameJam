using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnGrid : MonoBehaviour
{

    public GameObject cube;
    GameObject[] Cubes;
    public Button[] Buttons = new Button[9];
    private GameObject GridParent;
    public int playerCollisions = 0;
    private bool bChangeGameMode = true;


    //Materials
    public Material gridMaterial;
    public Material transparentGridMaterial;
    public Material enemyMaterial;
    public Material transparentEnemyMaterial;
    // Audio 
    public AudioSource audiosource;
    public AudioClip gridClick;
    public AudioClip UnclickGrid;



    //Player's default transform
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private Vector3 defaultScale;

    [SerializeField]
    private SpawnEnemy EnemySpawnerScript;

    //Reference to the GamemodeManager
    [SerializeField] private GamemodeManager gamemodeManager;
    private bool resetTransform = false;

    private void Awake()
    {
        //Initiate gamemodemanager reference
        gamemodeManager = GameObject.FindWithTag("GameController").GetComponent<GamemodeManager>();
    }

    private void Start()
    {
        Cubes = new GameObject[9];
        GridParent = GameObject.FindGameObjectWithTag("GridParent");
        EnemySpawnerScript = FindObjectOfType<SpawnEnemy>();

        //create default transform values
        defaultPosition = GridParent.transform.position;
        defaultRotation = GridParent.transform.rotation;
        defaultScale = GridParent.transform.localScale;
    }

    private void Update()
    {
      
        
        //If we return back to the adapt mode and haven't reset our transform
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt && !resetTransform)
        {
            ResetPlayerRotation();
            //Debug.Log("we ain't rollin");
        }

        //For Cube Transpareny

        //For Blue Cubes
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            if (Input.GetButton("Transparent"))
            {
                foreach (GameObject gridCube in Cubes)
                {
                    if (gridCube)
                    {
                        gridCube.GetComponent<MeshRenderer>().material = transparentGridMaterial;
                    }
                }

            }
            if (Input.GetButtonUp("Transparent"))
            {
                foreach (GameObject gridCube in Cubes)
                {
                    if (gridCube)
                    {
                        gridCube.GetComponent<MeshRenderer>().material = gridMaterial;
                    }
                }
            }

            foreach(GameObject enemyCube in EnemySpawnerScript.EnemyWall)
            {
                if (enemyCube && enemyCube.GetComponent<MeshRenderer>().material != enemyMaterial)
                {
                    enemyCube.GetComponent<MeshRenderer>().material = enemyMaterial;
                }
            }
        }
        //For Red Cubes
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
             if (Input.GetButton("Transparent"))
             {
                foreach (GameObject enemyCube in EnemySpawnerScript.EnemyWall)
                {
                    if (enemyCube)
                    {
                        enemyCube.GetComponent<MeshRenderer>().material = transparentEnemyMaterial;
                    }
                }

            }
            if (Input.GetButtonUp("Transparent"))
            {
                foreach (GameObject enemyCube in EnemySpawnerScript.EnemyWall)
                {
                    if (enemyCube)
                    {
                        enemyCube.GetComponent<MeshRenderer>().material = enemyMaterial;
                    }
                }
            }

            foreach (GameObject gridCube in Cubes)
            {
                if (gridCube && gridCube.GetComponent<MeshRenderer>().material != gridMaterial)
                {
                    gridCube.GetComponent<MeshRenderer>().material = gridMaterial;
                }
            }   
            
        }
    }

    // Audio functions
    void gridPress()
    {
        audiosource.clip = gridClick;
        audiosource.Play();
    }

    void depressGrid()
    {
        audiosource.clip = UnclickGrid;
        audiosource.Play();
    }

    //Methods used to spawn blocks

    public void Spawn1()
    {
        int indexPosition = 0;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            

            if (!Cubes[0])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(-1, 3, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else 
            {
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                Destroy(Cubes[indexPosition]);
                depressGrid();
            }
        }
        else if(gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[8].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[8].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    EnemySpawnerScript.EnemyWall[8].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[8].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[8].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[8].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();
                }
            }
        }
    }

    public void Spawn2()
    {
        int indexPosition = 1;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            
            if (!Cubes[indexPosition])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(0, 3, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[5].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[5].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    EnemySpawnerScript.EnemyWall[5].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[5].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[5].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[8].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();
                }
            }
        }
    }

    public void Spawn3()
    {
        int indexPosition = 2;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            
            if (!Cubes[indexPosition])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(1, 3, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[2].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[2].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    EnemySpawnerScript.EnemyWall[2].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[2].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[2].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[2].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();
                }
            }
        }
    }

    public void Spawn4()
    {
        int indexPosition = 3;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {

            if (!Cubes[indexPosition])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(-1, 2, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[7].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[7].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    EnemySpawnerScript.EnemyWall[7].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[7].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[7].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[7].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();
                }
            }
        }
    }

    public void Spawn5()
    {
        int indexPosition = 4;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {

            if (!Cubes[4])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(0, 2, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[4].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[4].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    EnemySpawnerScript.EnemyWall[4].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[4].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[4].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[4].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();
                }
            }
        }
    }

    public void Spawn6()
    {
        int indexPosition = 5;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            
            if (!Cubes[indexPosition])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(1, 2, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[1].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[1].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    EnemySpawnerScript.EnemyWall[1].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[1].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[1].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();
                }
            }
        }
    }

    public void Spawn7()
    {
        int indexPosition = 6;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            
            if (!Cubes[indexPosition])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(-1, 1, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[6].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[6].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    EnemySpawnerScript.EnemyWall[6].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[6].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[6].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[6].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();

                }
            }
        }
    }

    public void Spawn8()
    {
        int indexPosition = 7;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            
            if (!Cubes[indexPosition])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(0, 1, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[3].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[3].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    EnemySpawnerScript.EnemyWall[3].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[3].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[3].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[3].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();
                }
            }
        }
    }

    public void Spawn9()
    {
        int indexPosition = 8;
        //If we are currently in the Adapt gamemode
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            
            if (!Cubes[indexPosition])
            {
                Cubes[indexPosition] = Instantiate(cube, new Vector3(1, 1, 0), Quaternion.identity);
                Cubes[indexPosition].transform.parent = GridParent.transform;
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                gridPress();
            }
            else
            {
                Destroy(Cubes[indexPosition]);
                Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                depressGrid();
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (EnemySpawnerScript.EnemyWall[0].gameObject)
            {
                if (EnemySpawnerScript.EnemyWall[0].gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    EnemySpawnerScript.EnemyWall[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    EnemySpawnerScript.EnemyWall[0].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
                    gridPress();
                }
                else
                {
                    Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
                    EnemySpawnerScript.EnemyWall[0].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    EnemySpawnerScript.EnemyWall[0].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    depressGrid();

                }
            }
        }
    }

   /* public void RotatePlayer()
    {
        //Flip resetTransform
        resetTransform = !resetTransform;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Roll Forward");
            GridParent.transform.Rotate(new Vector3(GridParent.transform.rotation.x + 90f, 0f, 0f), Space.World);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Roll Left");
            GridParent.transform.Rotate(new Vector3(0f, 0f, GridParent.transform.rotation.z - 90f), Space.World);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Roll Right");
            GridParent.transform.Rotate(new Vector3(0f, 0f, GridParent.transform.rotation.z + 90f), Space.World);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Roll Backward");
            GridParent.transform.Rotate(new Vector3(GridParent.transform.rotation.x - 90f, 0f, 0f), Space.World);
        }
    }*/

    public void ResetPlayerRotation()
    {
        resetTransform = !resetTransform;

        GridParent.transform.rotation = defaultRotation;
        GridParent.transform.position = defaultPosition;
        GridParent.transform.localScale = defaultScale;

        //Destory any cubes left
        for(int i = 0; i < Cubes.Length-1; i++)
        {
            if (Cubes[i])
            {
                Destroy(Cubes[i]);
                Buttons[i].GetComponent<Image>().SetTransparency(0.2f);
            }
        }
    }
}
