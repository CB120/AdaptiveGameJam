using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIGridCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] UIGridManager gridManager;
    [SerializeField] int number;

    bool mouseOver = false;
    bool selected = false;

    void Start () {
        if (!gridManager) {
            gridManager = GetComponentInParent<UIGridManager>();
        }
    }

    void Update () {
        if (mouseOver) {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                gridManager.selecting = !selected;
            }
            if (Input.GetKey(KeyCode.Mouse0)) {
                TrySpawnMe();
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData) {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        mouseOver = false;
    }

    void TrySpawnMe () {
        if (selected != gridManager.selecting) {
            gridManager.Spawn(number);
            selected = !selected;
        }
    }

}
