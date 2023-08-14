using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIMANAGER : MonoBehaviour
{
    private static UIMANAGER instance;
    public Text scoreText;
    public int score;
    public Text highscoretext;
    public int highScore;
    
    private void Awake()
    {
         if (instance == null)
        {
            instance= this;
        }
         else
        {
            Destroy(gameObject);
        }
    }

     public static void updatescore(int s)
    {
        instance.score += s;
        instance.scoreText.text = instance.score.ToString();
    }

    public static void updatehighscore()
    {

    }

    



}
