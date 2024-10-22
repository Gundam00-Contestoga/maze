using System;
using UnityEngine;

public interface IGameUI
{
    void UpdateTimer(TimeSpan time);
    void UpdateScore(int score);
    void UpdateCurrentItem(Sprite itemIcon);

    void DisplayGameUI(bool isGameRunning);

    void DisplayStartMenu(bool isInStartMenu);

    void DisplayPauseScreen(bool isPaused);
}
