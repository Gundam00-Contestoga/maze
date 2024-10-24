using JetBrains.Annotations;
using System;
using TMPro.EditorUtilities;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    //Creating the objects
    public GameUI gameUI;
    //public PlayerMovement playerMovement;
    //public MazeController mazeController;
    //public ItemManager itemManager;
    public TimeManager timeManager;
    public ScoreManager scoreManager;

    
    //Variables
    public bool hasKey = false;
    public int score = 0;
    //public float gameTimer; //Time.deltaTime needs to be a float
    //public bool isGamePaused; Replaced by Time.timeScale
    public bool isWinner;
    public TimeSpan levelDuration;
    public int numberOfAttempts = 0;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        //Creating the object
        //timeManager = new TimeManager(levelDuration);
        //scoreManager = new ScoreManager();

        //Opening the Start Menu at the beginning of the game
        gameUI.DisplayStartMenu(true);
    }

    // Update is called once per frame
    public void Update()
    {
        //Update the timer every frame
        //ControlTimer();
        //Updating the time and checking is the time is ended
        if (timeManager.UpdateTime(Time.deltaTime))
        {
            isWinner = false;
            EndMaze();
        }
        else
        {
            //Updating the UI with the updated time
            gameUI.UpdateTimer(timeManager.GetGameTime());
        }

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
    public void StartMaze()
    {

        //UI needs to close the Start Menu
        gameUI.DisplayStartMenu(false);

        //Increase the timer using the number of attempts
        levelDuration = TimeSpan.FromMinutes(3 + numberOfAttempts);


        //Creating the objects
        timeManager = new TimeManager(levelDuration);
        scoreManager = new ScoreManager();

        hasKey = false;
        isWinner = false;
        score = 0;

        /*
            O Time.timeScale é uma propriedade do Unity que controla a velocidade do tempo do jogo. 
            É muito útil para pausar o jogo ou desacelerar o tempo.
            Time.timeScale = 1: O tempo do jogo está em velocidade normal.
            Time.timeScale = 0: O jogo está pausado (todas as atualizações de Update, animações e física param).
            Time.timeScale < 1: O jogo é desacelerado (ex.: 0.5 significa que o tempo passa à metade da velocidade normal).
        */
        //Game is running
        //Não preciso mais disso. Vou adiministrar na TimeManager
        //Time.timeScale = 1;


        //gameTimer = 300; //3 minutes

        //Starting the time
        timeManager.StartTime();

        //MazeController need to reset the mazer
        //mazeController.StartDefaultMaze();

        //UIManager needs to start with a default HUD
        //gameUI.StartDefaultUI();
        gameUI.DisplayGameUI(true);

        //PlayerController needs to enable the player
        //playerMovement.SetMovementEnabled(true);

    }


    //PlayerController need to disable the player movements
    //UIManager needs to display Pause screen
    public void PauseMaze()
    {
        //Pausing the timer
        //Time.timeScale = 0;
        timeManager.PauseTime();

        //Disalbe player movement
        //playerMovement.SetMovementEnabled(false);

        //Display Pause Screen
        gameUI.DisplayPauseScreen(true);

    }


    //PlayerController needs to enable the player movements
    //UIManager needs to close Pause screen
    public void ResumeMaze()
    {
        //Restarting the timer
        //Time.timeScale = 1;
        timeManager.ResumeTime();

        //Enable player movement
        //characterMovement.EnablePlayer();
        //playerMovement.SetMovementEnabled(true);

        //Close Pause Screen
        gameUI.DisplayPauseScreen(false);
    }

    //Control the timer
    //void ControlTimer()
    //{

    //    //Check if the game is over
    //    if (gameTimer <= 0)
    //    {
    //        isWinner = false;
    //        EndMaze();
    //    }
    //    else
    //    {
    //        //Decrease the timer for each second
    //        gameTimer -= Time.deltaTime;

    //        //Update the UI
    //        gameUI.UpdateTimer(gameTimer);
    //    }

    //}


    //Reset the Maze
    public void ResetMaze()
    {
        //Just call the StartMaze
        StartMaze();
    }


    //Control the collision with an item
    public void ControlCollision(GameObject item)
    {
        //Check if it is a key
        if (item.tag == "key")
        {
            hasKey = true;
            
            //Stoping the timer to display the message
            PauseMaze();
            
            //Increse the score
            //UpdateScore(100);
            scoreManager.UpdateScore(100);

            //gameUI.DisplayMsg("Key founded! Search for the exit door!");
        }
        else if (item.tag == "door")
        {
            if (hasKey)
            {
                isWinner = true;
                //UpdateScore(300);
                scoreManager.UpdateScore(300);

                EndMaze();
            }
            else
            {
                //Stoping the timer to display the message
                PauseMaze();
                //gameUI.DisplayMsg("You need a key to open this door!");
            }
        }
        else
        {
            //Call the ItemManager to handle the effects
            //itemManager.ApplyItemEffects(item);
        }

    }

    //End the maze and display the winner or loser screen
    public void EndMaze()
    {
        //Stoping the timer
        //Time.timeScale = 0;
        timeManager.PauseTime();

        //Updating UI Time
        gameUI.UpdateEndGameTimer(timeManager.GetGameTime());

        //Bonus Point
        //score += Convert.ToInt32(gameTimer * 10);
        int bonusPoints = Convert.ToInt32(timeManager.GetGameTime().TotalSeconds * 10);
        scoreManager.UpdateScore(bonusPoints);


        //Updating the UI Score
        //gameUI.UpdateScore(score);
        gameUI.UpdateEndGameScore(scoreManager.GetScore());

        //Disable player movements
        //playerMovement.SetMovementEnabled(false);

        //Increse the number of attempts
        if (!isWinner)
        {
            numberOfAttempts++;
        }

        //Call UI to display winner screen
        //gameUI.DisplayEndGame(isWinner);
    }

    //Update the score. Increase or decrease
    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
        gameUI.UpdateScore(score);
    }

    //Update the time system. Increase or decrease
    public void UpdateTime(float timeToUpdate)
    {
        //gameTimer += timeToUpdate;
        //gameUI.UpdateTimer(gameTimer);

        timeManager.AddTime(TimeSpan.FromSeconds(timeToUpdate));
        gameUI.UpdateTimer(timeManager.GetGameTime());

    }

    
    //Linking the buttons on Menus
    public void OnEnable()
    {
        GameUI.OnContinuePressed += ResumeMaze;
        GameUI.OnExitPressed += ExitGame;
        GameUI.OnStartPressed += StartMaze;
    }
    public void OnDisable()
    {
        GameUI.OnContinuePressed -= ResumeMaze;
        GameUI.OnExitPressed -= ExitGame;
        GameUI.OnStartPressed -= StartMaze;
    }
    //Closing the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
