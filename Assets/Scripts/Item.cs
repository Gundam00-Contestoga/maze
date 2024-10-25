using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;

    public Item(string name, Sprite sprite)
    {
        itemName = name;
        itemSprite = sprite;
    }
    public abstract void Use();
}
public class Clock : Item
{
    GameManager gameManager; /*--- Instância*/
    public float timeIncreaseAmount = 50;
    public Clock(string name, Sprite sprite): base(name, sprite)
    {
    }
    public override void Use() 
    {
        gameManager.UpdateTimer(timeIncreaseAmount);
    }
}
public class Boots : Item
{
    PlayerMovement playerMovement; /*--- Instância*/
    public float speedIncreaseAmount = 20;

    public Boots(string name, Sprite sprite) : base(name, sprite)
    {
    }
    public override void Use()
    {
        playerMovement.IncreaseSpeed(speedIncreaseAmount);
    }
}
public class Crow : Item
{
    PlayerMovement playerMovement; /*--- Instância*/

    public float visionIncreaseAmount = 20;
    public Crow(string name, Sprite sprite) : base(name, sprite)
    {
    }
    public override void Use()
    {
        playerMovement.IncreaseVision(visionIncreaseAmount);
    }
}
//public class Scythe : Item
//{
//    public Scythe(string name, Sprite sprite) : base(name, sprite)
//    {
//    }
//    public override void Use()
//    {
//    }
//}
