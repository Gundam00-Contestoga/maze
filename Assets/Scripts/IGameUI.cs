using UnityEngine;

public interface IGameUI
{
    void UpdateTimer(float time);
    void UpdateScore(int score);
    void UpdateCurrentItem(Sprite itemIcon);
}
