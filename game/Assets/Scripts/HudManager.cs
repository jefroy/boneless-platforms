﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    // score text label
    public Text scoreLabel;
    public Text livesLabel;
    // Start is called before the first frame update
    void Start()
    {
        // start with the correct score
        ResetHUD();
    }

    // show up-to-date stats of the player
    // add this method: on trigger of collecting a coin, enemy, start of game
    public void ResetHUD(){
        scoreLabel.text = "Score: " + GameManager.instance.playerScore;
        livesLabel.text = "Lives: " + GameManager.instance.playerLives;
    }
}
