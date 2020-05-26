using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //score of player
    public int playerScore = 0;
    public int levelScore = 0;
    public int playerLives = 3;
    public int defaultLives = 3;
    public int highScore = 0;
    public int currentLevel = 2;
    // amount of levels
    public int maxLevels = 3;
    // static instance of GM to be accessed from anywhere
    public static GameManager instance;
    // Awake is called before the game starts
    private HudManager hudManager;
    void Awake()
    {
        // check that it exists
        if(instance == null) instance = this;
        // check that it is equal to the current object
        else if(instance != this){
            instance.hudManager = FindObjectOfType<HudManager>();
            Destroy(gameObject);   
        } 
        //prevent this object from being destroyed when switching scenes
        DontDestroyOnLoad(gameObject);

        // find hud manager object
        hudManager = FindObjectOfType<HudManager>();
    }
    
    // increase player score
    public void IncreaseScore(int amount){
        playerScore += amount;
        levelScore += amount;
        if(hudManager != null) hudManager.ResetHUD();
        
        if(playerScore > highScore) highScore = playerScore;
        //hudMan.ResetHUD();
        print("new score: " + playerScore);
        print("high score: " + highScore);
    }

    public void ResetGame(){
        // reset score
        playerScore = 0;
        levelScore = 0;
        playerLives = defaultLives;
        // go back to level 1
        if(hudManager != null) hudManager.ResetHUD();
        currentLevel = 1;
        // load level 1 scene
        SceneManager.LoadScene("Level1");
    }
    
    public void ResetLevel(){
        // remove points collected on the level so far
        playerScore -= levelScore;
        levelScore = 0;
        // reset level
        if(hudManager != null) hudManager.ResetHUD();
        // load level 1 scene
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void Die(){
        playerLives--;
        if(playerLives <= 0) GameOver();
        else ResetLevel();
    }

    public void IncreaseLevel(){
        // check if their are more levels
        if(currentLevel < maxLevels){
            currentLevel++;
            playerLives++;
            levelScore = 0;
            SceneManager.LoadScene("Level" + currentLevel);
        }
        else{ // finish the game
            // go back to start
            currentLevel = 1;
            GameOver();
        }
        
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }

}
