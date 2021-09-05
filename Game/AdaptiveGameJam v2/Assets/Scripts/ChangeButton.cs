using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour
{

    private Image spriteRenderer;
    public Sprite blueSprite, redSprite;
    private GamemodeManager gamemodeManager;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
        gamemodeManager = FindObjectOfType<GamemodeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            spriteRenderer.sprite = blueSprite;
        }
        else
        {
            spriteRenderer.sprite = redSprite;
        }
    }
}
