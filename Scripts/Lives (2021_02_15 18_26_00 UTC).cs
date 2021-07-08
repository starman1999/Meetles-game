using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{

    int lives = 4;
    public TextMeshProUGUI livesText;
    int currentLives;
    public static Lives Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLives = lives;
    }

   
    public void changeLives(int amount)
    {
        currentLives += amount;
        if(currentLives > lives)
        {
           //currentLives = lives;
        }
        if (currentLives <= 0)
        {
            SceneManage.Instance.loadScene();
            currentLives = 0;
            Score.Instance.reset();
        }
        livesText.text = ""+currentLives;

    }
}
