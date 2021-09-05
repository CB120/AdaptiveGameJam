using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGridManager : MonoBehaviour
{
    public bool clicked;
    [SerializeField] SpawnGrid spawnGrid;
    public bool selecting = true;
    
    public void Spawn (int number) {
        switch(number) {
            case 0: spawnGrid.Spawn1(); break;
            case 1: spawnGrid.Spawn2(); break;
            case 2: spawnGrid.Spawn3(); break;
            case 3: spawnGrid.Spawn4(); break;
            case 4: spawnGrid.Spawn5(); break;
            case 5: spawnGrid.Spawn6(); break;
            case 6: spawnGrid.Spawn7(); break;
            case 7: spawnGrid.Spawn8(); break;
            case 8: spawnGrid.Spawn9(); break;
        }
    }

    public void DeselectAll()
    {
        foreach (UIGridCell cell in GetComponentsInChildren<UIGridCell>())
        {
            cell.selected = false;
        }
    }
}
