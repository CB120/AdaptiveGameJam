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
    public Material gridMaterial;
    public int playerCollisions = 0;

    private void Start()
    {
        Cubes = new GameObject[9];
        GridParent = GameObject.FindGameObjectWithTag("GridParent");
    }

    private void Update()
    {
       
    }


    public void Spawn1()
    {
        int indexPosition = 0;
        if (!Cubes[0])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(-1, 3, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
            Destroy(Cubes[indexPosition]);
        }
    }

    public void Spawn2()
    {
        int indexPosition = 1;
        if (!Cubes[indexPosition])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(0, 3, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }

    public void Spawn3()
    {
        int indexPosition = 2;
        if (!Cubes[indexPosition])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(1, 3, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }

    public void Spawn4()
    {
        int indexPosition = 3;
        if (!Cubes[indexPosition])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(-1, 2, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }

    public void Spawn5()
    {
        int indexPosition = 4;
        if (!Cubes[4])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(0, 2, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }

    public void Spawn6()
    {
        int indexPosition = 5;
        if (!Cubes[indexPosition])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(1, 2, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }

    public void Spawn7()
    {
        int indexPosition = 6;
        if (!Cubes[indexPosition])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(-1, 1, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }

    public void Spawn8()
    {
        int indexPosition = 7;
        if (!Cubes[indexPosition])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(0, 1, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }

    public void Spawn9()
    {
        int indexPosition = 8;
        if (!Cubes[indexPosition])
        {
            Cubes[indexPosition] = Instantiate(cube, new Vector3(1, 1, 0), Quaternion.identity);
            Cubes[indexPosition].transform.parent = GridParent.transform;
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(1);
        }
        else
        {
            Destroy(Cubes[indexPosition]);
            Buttons[indexPosition].GetComponent<Image>().SetTransparency(0.2f);
        }
    }



}
