using JetBrains.Annotations;
using TMPro.EditorUtilities;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    //Creating the objects
    public GameUI gameUI;
    public CharacterMovement characterMovement;
    public MazeController mazeController;

    public bool hasKey = false;
    public int score = 0;
    public float gameTimer; //Time.deltaTime needs to be a float
    public bool isGamePaused;
    public bool isWinner;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Reset the variables
    //MazeController needs to reset the maze
    //UIManager needs to start with a default HUD
    //PlayerController needs to enable the player movements
    void StartMaze()
    {
        hasKey = false;
        isGamePaused = false;
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
        isGamePaused = true;

        //Disalbe player movement
        characterMovement.DisablePlayer();

        //Display Pause Screen
        gameUI.DisplayPauseScreen();

    }


    //PlayerController needs to enable the player movements
    //UIManager needs to close Pause screen
    void ResumeMaze()
    {
        isGamePaused = false;
        //Enable player movement
        characterMovement.EnablePlayer();

        //Close Pause Screen
        gameUI.ClosePauseScreen();
    }

    //Control the timer
    void ControlTimer()
    {
        if (!isGamePaused)
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
    }


    //Reset the Maze
    void ResetMaze()
    {
        //Just call the StartMaze
        StartMaze();
    }


    //Control the collision with an item
    void ControlCollision()
    {
        //Check if it is a key
        if (item.tag == "key")
        {
            hasKey = true;
            //Stoping the timer to display the message
            isGamePaused = true;
            gameUI.DisplayMsg("Key founded! Search for the exit door!");
        }
        else if (item.tag == "door")
        {
            if (hasKey)
            {
                isWinner = true;
                EndMaze();
            }
            else
            {
                //Stoping the timer to display the message
                isGamePaused = true;
                gameUI.DisplayMsg("You need a key first!");
            }
        }
        else
        {
            //Get the item effects
        }

    }

    //End the maze and display the winner or loser screen
    void EndMaze()
    {
        isGamePaused = true;
        
        characterMovement.DisablePlayer();

        gameUI.DisplayEndGame(isWinner);
    }
}
