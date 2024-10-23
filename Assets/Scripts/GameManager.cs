using JetBrains.Annotations;
using System;
using TMPro.EditorUtilities;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    //Creating the objects
    public GameUI gameUI;
    public CharacterMovement characterMovement;
    public MazeController mazeController;
    public ItemManager itemManager;

    
    //Variables
    public bool hasKey = false;
    public int score = 0;
    public float gameTimer; //Time.deltaTime needs to be a float
    //public bool isGamePaused; Replaced by Time.timeScale
    public bool isWinner;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartMaze();

        //Opening the Start Menu at the beginning of the game
        gameUI.DisplayStartMenu(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Update the timer every frame
        ControlTimer();

        //Open the Pause Menu when pressed ESC or close if it is already open
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                PauseMaze();
            }
            else
            {
                ResumeMaze();
            }
        }
    }

    //Reset the variables
    //MazeController needs to reset the maze
    //UIManager needs to start with a default HUD
    //PlayerController needs to enable the player movements
    void StartMaze()
    {
        hasKey = false;

        /*
            O Time.timeScale é uma propriedade do Unity que controla a velocidade do tempo do jogo. 
            É muito útil para pausar o jogo ou desacelerar o tempo.
            Time.timeScale = 1: O tempo do jogo está em velocidade normal.
            Time.timeScale = 0: O jogo está pausado (todas as atualizações de Update, animações e física param).
            Time.timeScale < 1: O jogo é desacelerado (ex.: 0.5 significa que o tempo passa à metade da velocidade normal).
        */
        //Game is running
        Time.timeScale = 1;

        isWinner = false;
        score = 0;
        gameTimer = 300; //3 minutes

        //MazeController need to reset the mazer
        mazeController.StartDefaultMaze();

        //UIManager needs to start with a default HUD
        //gameUI.StartDefaultUI();
        gameUI.Start();

        //PlayerController needs to enable the player
        characterMovement.EnablePlayer();

    }


    //PlayerController need to disable the player movements
    //UIManager needs to display Pause screen
    void PauseMaze()
    {
        //Pausing the timer
        Time.timeScale = 0;

        //Disalbe player movement
        characterMovement.DisablePlayer();

        //Display Pause Screen
        gameUI.DisplayPauseScreen(true);

    }


    //PlayerController needs to enable the player movements
    //UIManager needs to close Pause screen
    void ResumeMaze()
    {
        //Restarting the timer
        Time.timeScale = 1;

        //Enable player movement
        characterMovement.EnablePlayer();

        //Close Pause Screen
        gameUI.DisplayPauseScreen(false);
    }

    //Control the timer
    void ControlTimer()
    {

        //Check if the game is over
        if (gameTimer <= 0)
        {
            isWinner = false;
            EndMaze();
        }
        else
        {
            //Decrease the timer for each second
            gameTimer -= Time.deltaTime;

            //Update the UI
            gameUI.UpdateTimer(gameTimer);
        }

    }


    //Reset the Maze
    void ResetMaze()
    {
        //Just call the StartMaze
        StartMaze();
    }


    //Control the collision with an item
    void ControlCollision(GameObject item)
    {
        //Check if it is a key
        if (item.tag == "key")
        {
            hasKey = true;
            
            //Stoping the timer to display the message
            PauseMaze();
            
            //Increse the score
            UpdateScore(100);

            gameUI.DisplayMsg("Key founded! Search for the exit door!");
        }
        else if (item.tag == "door")
        {
            if (hasKey)
            {
                isWinner = true;
                UpdateScore(300);
                EndMaze();
            }
            else
            {
                //Stoping the timer to display the message
                PauseMaze();
                gameUI.DisplayMsg("You need a key first!");
            }
        }
        else
        {
            //Call the ItemManager to handle the effects
            itemManager.ApplyItemEffects(item);
        }

    }

    //End the maze and display the winner or loser screen
    void EndMaze()
    {
        //Stoping the timer
        Time.timeScale = 0;

        //Bonus Point
        score += Convert.ToInt32(gameTimer * 10);

        //Updating the UI Score
        gameUI.UpdateScore(score);

        //Disable player movements
        characterMovement.DisablePlayer();

        //Call UI to display winner screen
        gameUI.DisplayEndGame(isWinner);
    }

    //Update the score. Increase or decrease
    void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
        gameUI.UpdateScore(score);
    }

    //Update the time system. Increase or decrease
    void UpdateTimer(float timeToUpdate)
    {
        gameTimer += timeToUpdate;
        gameUI.UpdateTimer(gameTimer);
    }

    
    //Linking the buttons on Pause Menu
    private void OnEnable()
    {
        GameUI.OnContinuePressed += ResumeMaze;
        GameUI.OnExitPressed += ExitGame;
    }
    private void OnDisable()
    {
        GameUI.OnContinuePressed -= ResumeMaze;
        GameUI.OnExitPressed -= ExitGame;
    }
    //Closing the game
    public void ExitGame()
    {
        Application.Quit();
    }


}
