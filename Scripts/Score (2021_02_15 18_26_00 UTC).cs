using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class Score : MonoBehaviour
{

    public static Score Instance;
    public TextMeshProUGUI AlienNumberText;
    public TextMeshProUGUI gameScore;
    public TextMeshProUGUI HighScoretext;
    public TextMeshProUGUI HighMeetlestext;





    public static int currentScore;
    public static int HighScore;
    public static int HighMeetles;


    public static int currentSaves;
    public static int AllSaves = 0;


    void Start()
    {
        currentSaves = 0;
        currentScore = 0;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }

    void Update()
    {
        HighScoretext.GetComponent<TextMeshProUGUI>().text = "High Score : " + HighScore;
        HighMeetlestext.GetComponent<TextMeshProUGUI>().text = "" + HighMeetles + " Meetles";

    }

    public void changeScore(int score)
    {
        if((currentScore + score)<= 0)
        {
            currentScore = -score;
        }

        gameScore.text = "" + (currentScore + score);

        currentScore = currentScore + score;
        if(currentScore <= 0)
        {
            currentScore = 0;
        }

        if (HighScore < currentScore) // if we pass the High Score we update our high score!
        {
            HighScore = currentScore;


        }


    }

    public void Saves(int AlienNumber)
    {
        AllSaves += AlienNumber;

        StartCoroutine(AliensSavedAnim());
        AlienNumberText.text = "" + (AlienNumber + currentSaves) ;
        currentSaves = AlienNumber + currentSaves;
        if (HighMeetles < currentSaves) //
        {
            HighMeetles = currentSaves;


        }

    }

    IEnumerator AliensSavedAnim()
    {
        AlienNumberText.fontSize = 26;
        yield return new WaitForSeconds(0.2f);
        AlienNumberText.fontSize = 23;
    }
    
    public void reset()
    {
        currentScore = 0;

    }


}
