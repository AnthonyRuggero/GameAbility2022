using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//exit button present in the main menu to exit the game
public class ExitGameButton : MonoBehaviour{
    public void QuitGame(){
        Application.Quit();
    }
}