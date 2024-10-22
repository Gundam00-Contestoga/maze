using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour, IGameUI
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public Image itemImage;
    public Image itemBackgroundImage;

    private float timeRemaining;

    void Start()
    {
        UpdateTimer(0);
        UpdateScore(0);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimer(timeRemaining);
        }
    }
    public void UpdateCurrentItem(Sprite itemSprite)
    {
        if (itemSprite != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = itemSprite;
        }
        else
        {
            itemImage.enabled = false;
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateTimer(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        timerText.text = "Timer: " + string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }
}
