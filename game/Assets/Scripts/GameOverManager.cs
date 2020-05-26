﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // access to the text element to show the score value
    public Text playerScoreValue;
    // access to the highscore value
    public Text highScoreValue;
    public Text winOrLose;

    // Start is called before the first frame update
    void Start()
    {
        // set the text property of the player score 
        playerScoreValue.text = GameManager.instance.playerScore.ToString();
        // set the text of high score
        highScoreValue.text = GameManager.instance.highScore.ToString();
        DetermineWin();
    }

    // send you to level 1
    public void ResetGame(){
        GameManager.instance.ResetGame();
        SceneManager.LoadScene("Level1");
    }

    public void DetermineWin(){
        string text;
        if(GameManager.instance.playerLives > 0) text = "You Win!";
        else text = "You Lose :(";
        winOrLose.text = text;
    }
}
