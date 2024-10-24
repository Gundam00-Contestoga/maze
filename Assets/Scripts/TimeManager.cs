using System;
using UnityEngine;

public class TimeManager
{

    public TimeSpan levelDuration;
    public TimeSpan gameTime;
    public bool isPaused;

    //Constructor. GameManager will call informing the level duration time
    public TimeManager(TimeSpan levelDuration)
    {
        this.levelDuration = levelDuration;
        this.gameTime = levelDuration;
        this.isPaused = false;
    }

    //Acho que não vou precisar disso, pq já está no constructor
    public void StartTime()
    {
        gameTime = levelDuration;
        isPaused = false;
    }


    //Atualiza o tempo e retorna se o tempo já acabou
    public bool UpdateTime(float deltaTime)
    {
        if (!isPaused)
        {
            gameTime -= TimeSpan.FromSeconds(deltaTime);
        }

        return gameTime <= TimeSpan.Zero;
    }

    public void PauseTime()
    {
        isPaused = true;
    }

    public void ResumeTime()
    {
        isPaused = false;
    }

    public void AddTime(TimeSpan timeToUpdate)
    {
        gameTime += timeToUpdate;
    }

    //public void DecreaseTime(TimeSpan timeToUpdate)
    //{
    //    gameTime -= timeToUpdate;
    //}

    public TimeSpan GetGameTime()
    {
        return gameTime;
    }

}
