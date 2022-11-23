using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] Movement PlayerMovement;
    public Animator FadeAnimator;
    [SerializeField] bool Level_2 = false;
    public void IncrementScore()
    {
        score++; //adds +1 to the score
        scoreText.text = "Score " + score; //increases the score text on the UI with +1
        PlayerMovement.speed += PlayerMovement.SpeedIncreasePerPoint; //increases speed of player movement as the player collects more coins

        

        if (score == 100) //when to switch levels depending on score
        {
            PlayerPrefs.SetInt("HS", score);
            Changelevels();
            
        }
    }

    private void Awake()
    {
        inst = this;
    }


    void Changelevels()
    {
        FadeAnimator.SetTrigger("FadeOut");
        score = PlayerPrefs.GetInt("HS"); //gets score from previous level
        SceneManager.LoadScene(1);

        score++; //adds +1 to the score
        scoreText.text = "Score " + score; //increases the score text on the UI with +1

        PlayerMovement.speed += PlayerMovement.SpeedIncreasePerPoint; //increases speed of player movement as the player collects more coins
    }
}
