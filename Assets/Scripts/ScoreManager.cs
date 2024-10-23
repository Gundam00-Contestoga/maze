using UnityEngine;

public class ScoreManager
{
    public int score;

    //Default Constructor with score equal zero
    public ScoreManager()
    {
        score = 0;
    }

    //Return the score
    public int GetScore()
    {
        return score;
    }

    //Reset the score to zero
    public void ResetScore()
    {
        score = 0;
    }

    //Increase or decrease the score
    //Use a negative number to decrease
    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
    }

}
