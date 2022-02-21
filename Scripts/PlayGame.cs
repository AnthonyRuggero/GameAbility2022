using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour{
    public bool isTheGamePaused = false;
    public Personaggio player;

    private int delay;
    
    public void Update(){
        //recall the character function that starts it and then starts the game
        player.walkingFarward();
        //check if the esc key is pressed
        if(Input.GetKeyDown(KeyCode.Escape)){
            //if you were already in pause, the game is resumed, otherwise you enter the pause menu
            if(isTheGamePaused){
                PlayTheGame(); 
            }else{
                PauseTheGame();
            }
        }
    }  
        
    void PlayTheGame(){
        //the game is started
        Time.timeScale = 1;
        //you go to the game scene
        SceneManager.LoadScene(1);
        //the pause is removed
        isTheGamePaused = false;
    }

    void PauseTheGame(){
        //the game stops
        Time.timeScale = 0;
        //you go to the pause menu scene
        SceneManager.LoadScene(2);
        //the pause is set
        isTheGamePaused = true;
    }

    public void gameOver(){
        //the game stops
        Time.timeScale = 0;
        //go to the Game Over scene
        SceneManager.LoadScene(3);
        //expect a period of time (with the use of a for because the delays brought problems)
       for(delay = 0; delay<100;delay++){
        
       }
       //the game is closed (not being able to restart it due to an OpenPause limit)
       Application.Quit();
      
        
    }
}
