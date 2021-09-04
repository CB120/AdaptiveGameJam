using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Sprite [] lifeSprites;

    [SerializeField] private Image lifeImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives(int currentLives)
    {
        lifeImage.sprite = lifeSprites[currentLives];
    }

    
}
