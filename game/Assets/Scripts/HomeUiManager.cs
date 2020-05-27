using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUiManager : MonoBehaviour
{
    // start level 1 when user clicks the button
    public void StartGame(){
        // load level 1 scene
        SceneManager.LoadScene("Level1");
    }

    // start level 1 when user clicks the button
    public void StartSubSpecial(){
        // load level 1 scene
        SceneManager.LoadScene("Level100");
    }
}
