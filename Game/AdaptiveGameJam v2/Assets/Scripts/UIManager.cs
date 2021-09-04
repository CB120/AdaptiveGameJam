using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] public Sprite [] lifeSprites;

    [SerializeField] public Image lifeImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives(int lives)
    {
        //lives = -1;
        //lifeImage.sprite = lifeSprites[lives];
    }

    
}
