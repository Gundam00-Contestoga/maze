using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour, IGameUI
{
    // Gameplay UI
    [Header("Gameplay UI")]
    public GameObject gameplayPanel;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI messageText;
    public Image itemImage;
    public Image itemBackgroundImage;
    private float timeRemaining;

    [Header("Inventory UI")]
    // Inventory
    public GameObject inventoryPanel;
    public List<Image> inventorySlots;

    [Header("Pause UI")]
    // Pause UI
    public GameObject pausePanel;
    public static event Action OnContinuePressed;
    public static event Action OnExitPressed;

    [Header("Start Menu UI")]
    // Start Menu
    public GameObject startPanel;
    public static event Action OnStartPressed;

    [Header("End Game UI")]
    // End Game
    public GameObject endGamePanel;
    public TextMeshProUGUI endGameTimerText;
    public TextMeshProUGUI endGameScoreText;


    #region Gameplay UI
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

        public void UpdateTimer(TimeSpan time)
        {        
            timerText.text = "Timer: " + string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
        }
    #endregion

    #region End Game UI

    public void UpdateEndGameScore(int score)
    {
        endGameScoreText.text = "Final Score: " + score.ToString();
    }

    public void UpdateEndGameTimer(TimeSpan time)
    {
        endGameTimerText.text = "Final Timer: " + string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }


    #endregion

    #region Inventory

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void UpdateInventoryUI(List<Sprite> inventoryItems)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (i < inventoryItems.Count)
            {
                inventorySlots[i].enabled = true;
                inventorySlots[i].sprite = inventoryItems[i];
            }
            else
            {
                inventorySlots[i].enabled = false;
            }
        }
    }

    #endregion

    #region Panels

    public void DisplayGameUI(bool isGameRunning)
    {
        gameplayPanel.SetActive(isGameRunning);
    }

    public void DisplayPauseScreen(bool isPaused)
    {
        pausePanel.SetActive(isPaused);
    }

    public void DisplayStartMenu(bool isInStartMenu)
    {
        startPanel.SetActive(isInStartMenu);
    }

    #endregion


    #region Buttons

    public void StartButtonPressed()
    {
        OnStartPressed?.Invoke();
    }

    public void ContinueButtonPressed()
    {
        OnContinuePressed?.Invoke();
    }

    public void ExitButtonPressed()
    {
        OnExitPressed?.Invoke();
    }



    #endregion


}
